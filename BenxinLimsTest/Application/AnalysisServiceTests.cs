using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using SqlSugar;
using BenXinLims.Application.Analysis;
using BenXinLims.Core;
using System.Linq.Expressions;
using System;

public class AnalysisServiceTests
{
    private readonly Mock<ISqlSugarClient> _dbContextMock;
    private readonly AnalysisServices _analysisService;

    public AnalysisServiceTests()
    {
        _dbContextMock = new Mock<ISqlSugarClient>();
        _analysisService = new AnalysisServices(_dbContextMock.Object);
    }

    [Fact]
    public async Task CreateAnalysis_ShouldReturnNumberOfInsertedRows()
    {
        // Arrange
        var analysisEntry = new AnalysisEntry();
        _dbContextMock.Setup(db => db.Insertable(It.IsAny<AnalysisEntry>()).ExecuteCommandAsync()).ReturnsAsync(1);

        // Act
        var result = await _analysisService.createAnalysis(analysisEntry);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task DeleteAnalysis_ShouldReturnNumberOfDeletedRows()
    {
        // Arrange
        var id = 1;
        _dbContextMock.Setup(db => db.Deleteable<AnalysisEntry>().Where(It.IsAny<Expression<Func<AnalysisEntry, bool>>>()).ExecuteCommandAsync()).ReturnsAsync(1);

        // Act
        var result = await _analysisService.deleteAnalysis(id);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task GetAnalysisList_ShouldReturnListOfAnalysisEntries()
    {
        // Arrange
        var expectedList = new List<AnalysisEntry> { new AnalysisEntry() };
        _dbContextMock.Setup(db => db.Queryable<AnalysisEntry>().ToListAsync()).ReturnsAsync(expectedList);

        // Act
        var result = await _analysisService.getAnalysisList();

        // Assert
        Assert.Equal(expectedList, result);
    }

    [Fact]
    public async Task UpdateAnalysis_ShouldReturnNumberOfUpdatedRows()
    {
        // Arrange
        var analysisEntry = new AnalysisEntry();
        var updateableMock = new Mock<IUpdateable<AnalysisEntry>>();
        updateableMock.Setup(u => u.IgnoreColumns(It.IsAny<Expression<Func<AnalysisEntry, object>>>())).Returns(updateableMock.Object);
        updateableMock.Setup(u => u.ExecuteCommandAsync()).ReturnsAsync(1);

        _dbContextMock.Setup(db => db.Updateable(It.IsAny<AnalysisEntry>())).Returns(updateableMock.Object);

        // Act
        var result = await _analysisService.updateAnalysis(analysisEntry);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task AddItemToAnalysis_ShouldReturnNegativeOneIfItemExists()
    {
        // Arrange
        var analysisItem = new AnalysisItemEntry { AnalysisName = "Analysis1", Name = "Item1" };
        _dbContextMock.Setup(db => db.Queryable<AnalysisItemEntry>().Where(It.IsAny<Expression<Func<AnalysisItemEntry, bool>>>()).FirstAsync()).ReturnsAsync(new AnalysisItemEntry());

        // Act
        var result = await _analysisService.addItemToAnalysis(analysisItem);

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public async Task AddItemToAnalysis_ShouldReturnNumberOfInsertedRowsIfItemDoesNotExist()
    {
        // Arrange
        var analysisItem = new AnalysisItemEntry { AnalysisName = "Analysis1", Name = "Item1" };
        _dbContextMock.Setup(db => db.Queryable<AnalysisItemEntry>().Where(It.IsAny<Expression<Func<AnalysisItemEntry, bool>>>()).FirstAsync()).ReturnsAsync((AnalysisItemEntry)null);
        _dbContextMock.Setup(db => db.Insertable(analysisItem).ExecuteCommandAsync()).ReturnsAsync(1);

        // Act
        var result = await _analysisService.addItemToAnalysis(analysisItem);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task DeleteItemFromAnalysis_ShouldReturnNumberOfDeletedRows()
    {
        // Arrange
        var id = 1;
        _dbContextMock.Setup(db => db.Deleteable<AnalysisItemEntry>().Where(It.IsAny<Expression<Func<AnalysisItemEntry, bool>>>()).ExecuteCommandAsync()).ReturnsAsync(1);

        // Act
        var result = await _analysisService.deleteItemFromAnalysis(id);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task GetItemListFromAnalysis_ShouldReturnListOfAnalysisItemEntries()
    {
        // Arrange
        var analysisName = "Analysis1";
        var expectedList = new List<AnalysisItemEntry> { new AnalysisItemEntry() };
        _dbContextMock.Setup(db => db.Queryable<AnalysisItemEntry>().Where(It.IsAny<Expression<Func<AnalysisItemEntry, bool>>>()).ToListAsync()).ReturnsAsync(expectedList);

        // Act
        var result = await _analysisService.getItemListFromAnalysis(analysisName);

        // Assert
        Assert.Equal(expectedList, result);
    }

    [Fact]
    public async Task UpdateItemFromAnalysis_ShouldReturnNegativeOneIfItemDoesNotExist()
    {
        // Arrange
        var analysisItem = new AnalysisItemEntry { AnalysisName = "Analysis1", Name = "Item1" };
        _dbContextMock.Setup(db => db.Queryable<AnalysisItemEntry>().Where(It.IsAny<Expression<Func<AnalysisItemEntry, bool>>>()).FirstAsync()).ReturnsAsync((AnalysisItemEntry)null);

        // Act
        var result = await _analysisService.updateItemFromAnalysis(analysisItem);

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public async Task UpdateItemFromAnalysis_ShouldReturnNumberOfUpdatedRowsIfItemExists()
    {
        // Arrange
        var analysisItem = new AnalysisItemEntry { AnalysisName = "Analysis1", Name = "Item1",Id=1 };
        var existingItem = new AnalysisItemEntry { AnalysisName = "Analysis1", Name = "Item1",Id=1 };

        // 模拟 Queryable 和 FirstAsync 方法
        var queryableMock = new Mock<ISugarQueryable<AnalysisItemEntry>>();
        queryableMock.Setup(q => q.Where(It.IsAny<Expression<Func<AnalysisItemEntry, bool>>>()))
                      .Returns(queryableMock.Object);
        queryableMock.Setup(q => q.FirstAsync()).ReturnsAsync(existingItem);

        _dbContextMock.Setup(db => db.Queryable<AnalysisItemEntry>()).Returns(queryableMock.Object);

        // 模拟 Updateable 和 IgnoreColumns 方法
        var updateableMock = new Mock<IUpdateable<AnalysisItemEntry>>();
        updateableMock.Setup(u => u.IgnoreColumns(It.IsAny<Expression<Func<AnalysisItemEntry, object>>>())).Returns(updateableMock.Object);
        updateableMock.Setup(u => u.ExecuteCommandAsync()).ReturnsAsync(1);

        _dbContextMock.Setup(db => db.Updateable(It.IsAny<AnalysisItemEntry>())).Returns(updateableMock.Object);

        // Act
        var result = await _analysisService.updateItemFromAnalysis(analysisItem);

        // Assert
        Assert.Equal(1, result);
    }
}
