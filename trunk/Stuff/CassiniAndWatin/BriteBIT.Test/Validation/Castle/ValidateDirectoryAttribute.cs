using System;
using Castle.Components.Validator;

namespace BriteBIT.Stuff.Validation.Castle
{
    /// <summary>
    /// Validate that the specifed directory exists.
    /// </summary>
    [Serializable]
    public class ValidateDirectoryAttribute : AbstractValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateDirectoryAttribute"/> class.
        /// </summary>
        public ValidateDirectoryAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateDirectoryAttribute"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public ValidateDirectoryAttribute(String errorMessage) : base(errorMessage)
        {
        }

        /// <summary>
        /// Constructs and configures an <see cref="IValidator"/>
        /// instance based on the properties set on the attribute instance.
        /// </summary>
        /// <returns></returns>
        public override IValidator Build()
        {
            IValidator validator = new DirectoryValidator();

            ConfigureValidatorMessage(validator);

            return validator;
        }
    }
}