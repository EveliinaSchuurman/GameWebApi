using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public enum Tag 
        {
            ACTIVE,
            DEAD,
            DONE
        }

namespace GameWebApi{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int Level { get; set; }
        public bool IsBanned { get; set; }
        
        [EnumDataType(typeof(Tag))]
        public Tag Tag { get; set; }

        public List<Item> itemList = new List<Item>();
        public DateTime CreationTime { get; set; }

        public static implicit operator Task<object>(Player v){
            throw new NotImplementedException();
        }
    }
}