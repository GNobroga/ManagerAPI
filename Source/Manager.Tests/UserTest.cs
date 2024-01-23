using AutoMapper;
using FluentAssertions;
using Manager.Application.DTOs;
using Manager.Application.Mappings;
using Manager.Domain.Entities;
using Manager.Domain.Interfaces;
using Manager.Domain.Validators;
using Manager.Service;
using Marraia.Notifications.Interfaces;
using Moq;
namespace Manager.Tests;

public class UserTests
{

    private readonly IMapper _mapper = new Mapper(new MapperConfiguration(options => options.AddProfile<MappingProfile>()));

    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    private readonly Mock<ISmartNotification> _smartNotificationMock = new();


    [Fact(DisplayName = "Pode cadastrar usuário com o mesmo e-mail")]
    public async Task Create_WhenAlreadyExistEmail()
    {
        var userDTO = new UserDTO("Gabriel", "livinha@gmail.com", "camilo123");
        var userService = new UserService(_userRepositoryMock.Object, _mapper, _smartNotificationMock.Object);
        var user = _mapper.Map<User>(userDTO);

        _userRepositoryMock.Setup(x => x.FindByEmail(It.IsAny<string>())).ReturnsAsync(user);

        _userRepositoryMock.Setup(x => x.CreateAsync(user)).ReturnsAsync(user);

        var result = await userService.CreateAsync(userDTO);

        result.Should().BeNull(because: "Já existe usuário com o email especificado");
    }

    [Fact(DisplayName = "Pode criar instância de usuário com campos inválidos")]
    public void Create_WhenUserFieldsIsInvalid()
    {
        var userDTO = new UserDTO("Gabriel", "livlcom", "camilo123");

        Action act = () => _mapper.Map<User>(userDTO);
   
        act.Should().Throw<DomainValidationException>().WithMessage("Alguns campos do usuário são invalidos");
    }

}