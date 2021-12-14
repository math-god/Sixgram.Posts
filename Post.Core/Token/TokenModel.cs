using System;

namespace Post.Core.Token
{
    public class TokenModel
    {
        public TokenModel(string token, long expiration)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Invalid token.");

            if (expiration <= 0)
                throw new ArgumentException("Invalid expiration.");

            Token = token;
            Expiration = expiration;
        }

        public string Token { get; set; }
        public long Expiration { get; set; }
    }
}