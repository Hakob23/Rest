namespace KushtPor
{
    /// <summary>
    /// struct to keep role accesstoken pair
    /// </summary>
    public struct RoleAndToken
    {
        // role
        public string role { get; set; }

        // accesstoken
        public string token { get; set; }

        public RoleAndToken(string role, string token)
        {
            this.role = role;
            this.token = token;
        }
    }
}
