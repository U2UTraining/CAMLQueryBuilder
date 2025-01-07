using System;

namespace U2U.SharePoint.CAML
{
    public class ListInfo : ICloneable
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        #region ICloneable Members

        public object Clone()
        {
            return new ListInfo() { Id = this.Id, Name = this.Name, ImageUrl = this.ImageUrl };
        }

        #endregion
    }
}
