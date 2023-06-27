using System;
namespace JLAHeadquarters.StorageApp.Entities
{
    public class Hero:EntityBase	
	{
		public string? HeroName { get; set; }

        public override string ToString() => $"Id: {Id}, Hero Name: {HeroName}";
    }
}

