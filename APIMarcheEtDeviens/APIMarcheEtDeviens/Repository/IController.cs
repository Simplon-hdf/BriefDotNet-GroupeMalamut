namespace APIMarcheEtDeviens.Repository
{
	public interface IController<T, Type>
	{
		Task<List<Type?>> GetAll();
		Task<Type?> GetById(T id);
		Task<List<Type?>> Add(Type type);
		Task<List<Type?>> Update(T id, Type type);
		Task<List<Type?>> DeleteById(T id);
	}
}
