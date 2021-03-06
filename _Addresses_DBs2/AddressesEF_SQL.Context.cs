//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _Addresses_DBs2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NamesAddressesEntities_SQL : DbContext
    {
        public NamesAddressesEntities_SQL()
            : base("name=NamesAddressesEntities_SQL")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int InsertNameAddress(string firstName, string lastName, string dwellingNumber, string apartment, string streetName, string streetType, string town, string state, string zip)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var dwellingNumberParameter = dwellingNumber != null ?
                new ObjectParameter("dwellingNumber", dwellingNumber) :
                new ObjectParameter("dwellingNumber", typeof(string));
    
            var apartmentParameter = apartment != null ?
                new ObjectParameter("apartment", apartment) :
                new ObjectParameter("apartment", typeof(string));
    
            var streetNameParameter = streetName != null ?
                new ObjectParameter("streetName", streetName) :
                new ObjectParameter("streetName", typeof(string));
    
            var streetTypeParameter = streetType != null ?
                new ObjectParameter("streetType", streetType) :
                new ObjectParameter("streetType", typeof(string));
    
            var townParameter = town != null ?
                new ObjectParameter("town", town) :
                new ObjectParameter("town", typeof(string));
    
            var stateParameter = state != null ?
                new ObjectParameter("state", state) :
                new ObjectParameter("state", typeof(string));
    
            var zipParameter = zip != null ?
                new ObjectParameter("zip", zip) :
                new ObjectParameter("zip", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertNameAddress", firstNameParameter, lastNameParameter, dwellingNumberParameter, apartmentParameter, streetNameParameter, streetTypeParameter, townParameter, stateParameter, zipParameter);
        }
    
        public virtual int TruncateNamesAddresses()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TruncateNamesAddresses");
        }
    }
}
