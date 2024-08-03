using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Mobile_StoreAPI
{
    public abstract class BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [JsonProperty("id")]
        public virtual int Id { get; set; }
    }
}