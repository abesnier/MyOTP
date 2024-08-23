using System.ComponentModel;
using OtpNet;

namespace MyOTP
{
    public class TotpObject : IDisposable
    {
        private readonly OtpHashMode _hashmode;
        private readonly Totp _totp = null!;
        private readonly CancellationTokenSource _cts = new();
        private bool _disposed;

        //public AppObject App { get; }

        public int Id { get; set; }

        [DisplayName("Application")]
        public string AppName { get; set; } = null!;
        public string Key { get; set; } = null!;
        public string HashMode { get; set; } = null!;
        public int Size { get; set; }
        public string? Url { get; set; } = null!;

        [DisplayName("User Name")]
        public string? UserName { get; set; } = null!;

        [DisplayName("Code")]
        public string Token { get { return _totp.ComputeTotp(DateTime.UtcNow); } }

        public int Remaining { get { return _totp.RemainingSeconds(); } }

        public int Step { get; set; }

        public TotpObject() { }



        public TotpObject(int id, string appName, string key, int step, string hashMode, int size, string? userName, string? url)
        {
            Id = id;
            AppName = appName;
            Key = key;
            HashMode = hashMode;
            Size = size;
            UserName = userName;
            Url = url;
            Step = step;

            _hashmode = HashMode switch
            {
                "sha1" => OtpHashMode.Sha1,
                "sha256" => OtpHashMode.Sha256,
                "sha512" => OtpHashMode.Sha512,
                _ => OtpHashMode.Sha1,
            };
            byte[] secretKey = Base32Encoding.ToBytes(Key);
            _totp = new Totp(secretKey, mode: _hashmode, step: Step, totpSize: Size);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _cts.Cancel();
            }
            _disposed = true;
        }
    }
}
