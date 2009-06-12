using System.IO;
using Castle.Components.Validator;

namespace BriteBIT.Stuff.Validation.Castle
{
    public class DirectoryValidator : AbstractValidator
    {
        /// <summary>
        /// Gets a value indicating whether this validator supports browser validation.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if browser validation is supported; otherwise, <see langword="false" />.
        /// </value>
        public override bool SupportsBrowserValidation
        {
            get { return false; }
        }

        /// <summary>
        /// Check that the directory specified by this property exists
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fieldValue"></param>
        /// <returns><c>true</c> if the field is OK</returns>
        public override bool IsValid(object instance, object fieldValue)
        {
            var path = fieldValue as string;
            return !string.IsNullOrEmpty(path) && Directory.Exists(path);
        }
    }
}