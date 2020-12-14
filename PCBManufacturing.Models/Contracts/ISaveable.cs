namespace PCBManufacturing.Models.Contracts
{
    public interface ISaveable<T>
    {
        T Save();
    }
}
