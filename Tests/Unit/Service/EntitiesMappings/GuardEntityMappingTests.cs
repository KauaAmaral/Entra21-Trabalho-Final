using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Unit.Service.EntitiesMappings
{
    public class GuardEntityMappingTests
    {
        private readonly IGuardEntityMapping _guardEntityMapping;
        public GuardEntityMappingTests()
        {
            _guardEntityMapping = new GuardEntityMapping();
        }

        [Fact]
        public void Test_RegisterWith()
        {
            // Arrange
            var viewModel = new GuardRegisterViewModel
            {
                IdentificationNumber = "123456789",
                UserId = 5,
            };

            // Act
            var guard = _guardEntityMapping.RegisterWith(viewModel);

            // Assert
            guard.IdentificationNumber.Should().Be(viewModel.IdentificationNumber);
            guard.UserId.Should().Be(viewModel.UserId);
        }

        [Fact]
        public void Test_UpdateWith()
        {
            // Arrange
            var guard = new Guard
            {
                IdentificationNumber = "495632012",               
            };

            var viewModelEdit = new GuardUpdateViewModel
            {
                IdentificationNumber = "471123685",                 
                Id = 4,
            };

            // Act
            _guardEntityMapping.UpdateWith(guard, viewModelEdit);

            // Assert
            guard.IdentificationNumber.Should().Be(viewModelEdit.IdentificationNumber);            
        }
    }
}
