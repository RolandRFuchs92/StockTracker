namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IEditStock
    {
	    bool Edit(int stockItemId, int par, bool isMin);
	    bool Edit(int stockItemId, int categoryId);
	    bool Edit(int stockItemId, string stockName);
	    bool Edit(int stockItemId, decimal price);
    }
}
