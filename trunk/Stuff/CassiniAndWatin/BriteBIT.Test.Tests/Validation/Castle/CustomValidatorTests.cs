using System.IO;
using BriteBIT.Stuff.Validation.Castle;
using BriteBIT.Validation;
using Castle.Components.Validator;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BriteBIT.Stuff.Tests.Validation.Castle
{
    [TestFixture]
    public class CustomValidatorTests
    {
        #region Setup/Teardown

        [SetUp]
        public void Init()
        {
            _directoryValidator = new DirectoryValidator();
            _directoryValidator.Initialize(new CachedValidationRegistry(),
                                           typeof (TestTarget).GetProperty("TargetField"));

            _filePathValidator = new FilePathValidator();
            _filePathValidator.Initialize(new CachedValidationRegistry(), typeof (TestTarget).GetProperty("TargetField"));

            _target = new TestTarget();
        }

        #endregion

        private DirectoryValidator _directoryValidator;
        private FilePathValidator _filePathValidator;
        private TestTarget _target;

        private class TestTarget
        {
            public string TargetField { get; set; }
        }

        [Test]
        public void DirectoryValidatorIsValid_EmptyStringPassedIn_ReturnsFalse()
        {
            Assert.That(_directoryValidator.IsValid(_target, string.Empty), Is.False);
        }

        [Test]
        public void DirectoryValidatorIsValid_InvalidDirectoryPassedIn_ReturnFalse()
        {
            Assert.That(_directoryValidator.IsValid(_target, "This directory does not exist"), Is.False);
        }

        [Test]
        public void DirectoryValidatorIsValid_ValidDirectoryPassedIn_ReturnTrue()
        {
            const string targetDirectory = @"c:\windows";
            if (!Directory.Exists(targetDirectory))
            {
                Assert.Fail(string.Format("The directory to test against does not exist. '{0}'", targetDirectory));
            }

            Assert.That(_directoryValidator.IsValid(_target, targetDirectory), Is.True);
        }

        [Test]
        public void FileValidatorIsValid_EmptyStringPassedIn_ReturnsFalse()
        {
            Assert.That(_filePathValidator.IsValid(_target, string.Empty), Is.False);
        }

        [Test]
        public void FileValidatorIsValid_InvalidDirectoryPassedIn_ReturnFalse()
        {
            Assert.That(_filePathValidator.IsValid(_target, "This directory does not exist"), Is.False);
        }

        [Test]
        public void FileValidatorIsValid_ValidDirectoryPassedIn_ReturnTrue()
        {
            const string targetFile = @"c:\windows\explorer.exe";
            if (!File.Exists(targetFile))
            {
                Assert.Fail(string.Format("The file to test against does not exist. '{0}'", targetFile));
            }

            Assert.That(_filePathValidator.IsValid(_target, targetFile), Is.True);
        }
    }
}