using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Moq;
using Restaurants.Clean.API;
using Restaurants.Clean.Application;

namespace Restaurant.API.Test;

public class ExceptionMiddlewareTest
{
    private readonly Mock<ILogger<ExceptionMiddleware>> _logger;
    private readonly ExceptionMiddleware _middleware;
    private readonly DefaultHttpContext _context;
    public ExceptionMiddlewareTest()
    {
        _logger=new Mock<ILogger<ExceptionMiddleware>>();
        _middleware = new ExceptionMiddleware(_logger.Object);
        _context = new DefaultHttpContext();
    }
    [Fact]
    public async Task InvokeAsync_WhenNoExceptionThrown_shouldBeCallNextDelegate()
    {
        //arange
        var next = new Mock<RequestDelegate>();

        //act
        await _middleware.InvokeAsync(_context,  next.Object);

        //assert
        next.Verify(x => x.Invoke(_context), Times.Once);

    }
    [Fact]
    public async Task InvokeAsync_WhenNotFoundExceptionThrown_ShouldRetunStatusCode404()
    {
        //arange
        var notFoundException = new NotFoundException("Restaurant","1");

        //act
        await _middleware.InvokeAsync(_context,  _=> throw notFoundException);

        //assert
        _context.Response.StatusCode.Should().Be(404);

    }
    [Fact]
    public async Task InvokeAsync_WhenForbidExceptionThrown_ShouldRetunStatusCode403()
    {
        //arange
        var forbidException = new ForbidException();

        //act
        await _middleware.InvokeAsync(_context,  _=> throw forbidException);

        //assert
        _context.Response.StatusCode.Should().Be(403);
    }
    [Fact]
    public async Task InvokeAsync_WhenExceptionThrown_ShouldRetunStatusCode500()
    {
        //arange
        var exception = new Exception();

        //act
        await _middleware.InvokeAsync(_context,  _=> throw exception);

        //assert
        _context.Response.StatusCode.Should().Be(500);
    }


}
