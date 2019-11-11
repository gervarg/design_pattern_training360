using System;
using System.IO;

namespace Builder
{
    class FileNameBuilder
    {
        private string extension;
        private string directory;
        private string fileNameWithoutExtension;
        private string prefix;
        private string postfix;
        private bool isUnique;

        public FileNameBuilder(string fileNameWithoutExtension = "", string extension = "", string directory = "", string prefix = "", string postfix = "", bool isUnique = false)
        {
            this.fileNameWithoutExtension = fileNameWithoutExtension;
            this.extension = extension;
            this.directory = directory;
            this.prefix = prefix;
            this.postfix = postfix;
            this.isUnique = isUnique;
        }

        public FileNameBuilder()
        {            
        }

        public FileNameBuilder AddExtension(string extension)
        {
            this.extension = extension;
            return this;
        }

        public FileNameBuilder AddDirectory(string directory)
        {
            this.directory = directory;
            return this;
        }

        public FileNameBuilder AddFileNameWithoutExtension(string fileNameWithoutExtension)
        {
            this.fileNameWithoutExtension = fileNameWithoutExtension;
            return this;
        }

        public FileNameBuilder AddPrefix(string prefix)
        {
            this.prefix = prefix;
            return this;
        }

        public FileNameBuilder AddPostfix(string postfix)
        {
            this.postfix = postfix;
            return this;
        }

        public FileNameBuilder IsUnique(bool isUnique)
        {
            this.isUnique = isUnique;
            return this;
        }

        // The build method
        public override string ToString()
        {                     
            var guid = isUnique ? "_" + Guid.NewGuid().ToString("N") : string.Empty;
            var fileName = $"{prefix}{fileNameWithoutExtension}{guid}{postfix}{extension}";
            return Path.Combine(directory, fileName);
        }
    }
}
