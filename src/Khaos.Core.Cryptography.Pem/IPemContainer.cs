namespace Khaos.Core.Cryptography.Pem
{
    public interface IPemContainer
    {
        string Format { get; }

        byte[] Content { get; }
    }
}