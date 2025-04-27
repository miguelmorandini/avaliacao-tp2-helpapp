using HelpApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using HelpApp.Domain.Validation;
using System.Runtime.CompilerServices;

namespace HelpApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create a Valid Category With a Default Name and Id")]
        public void CreateCategory_WithValidNameAndId_ResultObjectValidState()
        {
            Action action = () => new Category("Category Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos
        [Theory(DisplayName = "Create Category With Name Empty")]
        [InlineData("")]
        public void CreateCategory_WithNameEmpty_ResultObjetcException(string name)
        {
            Action action = () => new Category(name);
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Category With Id Invalid")]
        public void CreateCategory_WithIdInvalid_ResultObjectException()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Theory(DisplayName = "Create Category With Too Short")]
        [InlineData("M")]
        [InlineData("ig")]
        public void CreateCategory_WithTooShort_ResultObjectException(string name)
        {
            Action action = () => new Category(name);
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Theory(DisplayName = "Create Category With Name Null")]
        [InlineData(null)]
        public void CreateCategory_WithNameNull_ResultObjectException(string name)
        {
            Action action = () => new Category(name);
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }
        #endregion
    }
}
