namespace ProjectMarketPlace.Common
{
    public static class Helper
    {
        public static byte[] ToByteArray(IFormFile? file)
        {
            using (var stream = new MemoryStream((int)file?.Length!))
            {
                file.CopyTo(stream);
                return stream.ToArray();

            }

        } 
    }
}
