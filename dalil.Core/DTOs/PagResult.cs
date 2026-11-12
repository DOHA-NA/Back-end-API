namespace ApiCe.Core.PagResult
{
    public record PagResult<T>(List<T>Items ,int Pag , int PagSize , int TotalCount)
    {
        public int TotalPages => (int)Math.Ceiling((Double)TotalCount / PagSize);
    }
    
}