using System;
using Castle.Components.Validator;

namespace BriteBIT.Validation
{
    /// <summary>
    /// Validate that the specifed file exists.
    /// </summary>
    [Serializable]
    public class ValidateFilePathAttribute : AbstractValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateFilePathAttribute"/> class.
        /// </summary>
        public ValidateFilePathAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateFilePathAttribute"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public ValidateFilePathAttribute(String errorMessage) : base(errorMessage)
        {
        }

        /// <summary>
        /// Constructs and configures an <see cref="IValidator"/>
        /// instance based on the properties set on the attribute instance.
        /// </summary>
        /// <returns></returns>
        public override IValidator Build()
        {
            IValidator validator = new FilePathValidator();

            ConfigureValidatorMessage(validator);

            return validator;
        }
    }
}