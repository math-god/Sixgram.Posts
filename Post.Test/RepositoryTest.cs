using Post.Database.Repository.Subscription;
using Xunit;
using Moq;

namespace Post.Test;

public class RepositoryTest
{
    [Fact]
    public void GetByFilterResult()
    {
        // Arrange
        var mock = new Mock<ISubscriptionRepository>();
        /*mock.Setup(repo =>
                repo.GetByFilter(p
                    => p.RespondentId == new Guid("B52F727F-88D5-43AD-B9DA-9038BBAABE44")).Result)
            .Returns(AdditionalMethods.GetTestSubscriptions());*/
        // Act
        var subsList = mock.
        // Assert
    }
}