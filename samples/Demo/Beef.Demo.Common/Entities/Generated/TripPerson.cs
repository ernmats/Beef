/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Beef.RefData;
using Newtonsoft.Json;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Entities
{
    /// <summary>
    /// Represents the Trip Person entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class TripPerson : EntityBase, IStringIdentifier, IEquatable<TripPerson>
    {
        #region Privates

        private string? _id;
        private string? _firstName;
        private string? _lastName;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="TripPerson"/> identifier (username).
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Identifier")]
        public string? Id
        {
            get => _id;
            set => SetValue(ref _id, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(Id)); 
        }

        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        [JsonProperty("firstName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="First Name")]
        public string? FirstName
        {
            get => _firstName;
            set => SetValue(ref _firstName, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(FirstName)); 
        }

        /// <summary>
        /// Gets or sets the Last Name.
        /// </summary>
        [JsonProperty("lastName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Last Name")]
        public string? LastName
        {
            get => _lastName;
            set => SetValue(ref _lastName, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(LastName)); 
        }

        #endregion

        #region UniqueKey
      
        /// <summary>
        /// Indicates whether the <see cref="TripPerson"/> has a <see cref="UniqueKey"/> value.
        /// </summary>
        public override bool HasUniqueKey => true;
        
        /// <summary>
        /// Gets the list of property names that represent the unique key.
        /// </summary>
        public override string[] UniqueKeyProperties => new string[] { nameof(Id) };
        
        /// <summary>
        /// Creates the <see cref="UniqueKey"/>.
        /// </summary>
        /// <returns>The <see cref="Beef.Entities.UniqueKey"/>.</returns>
        /// <param name="id">The <see cref="Id"/>.</param>
        public static UniqueKey CreateUniqueKey(string id) => new UniqueKey(id);
          
        /// <summary>
        /// Gets the <see cref="UniqueKey"/>.
        /// </summary>
        /// <remarks>
        /// The <b>UniqueKey</b> key consists of the following property(s): <see cref="Id"/>.
        /// </remarks>
        public override UniqueKey UniqueKey => new UniqueKey(Id);

        #endregion

        #region IEquatable

        /// <summary>
        /// Determines whether the specified object is equal to the current object by comparing the values of all the properties.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is TripPerson val))
                return false;

            return Equals(val);
        }

        /// <summary>
        /// Determines whether the specified <see cref="TripPerson"/> is equal to the current <see cref="TripPerson"/> by comparing the values of all the properties.
        /// </summary>
        /// <param name="value">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public bool Equals(TripPerson? value)
        {
            if (((object)value!) == ((object)this))
                return true;
            else if (((object)value!) == null)
                return false;

            return base.Equals((object)value)
                && Equals(Id, value.Id)
                && Equals(FirstName, value.FirstName)
                && Equals(LastName, value.LastName);
        }

        /// <summary>
        /// Compares two <see cref="TripPerson"/> types for equality.
        /// </summary>
        /// <param name="a"><see cref="TripPerson"/> A.</param>
        /// <param name="b"><see cref="TripPerson"/> B.</param>
        /// <returns><c>true</c> indicates equal; otherwise, <c>false</c> for not equal.</returns>
        public static bool operator == (TripPerson? a, TripPerson? b) => Equals(a, b);

        /// <summary>
        /// Compares two <see cref="TripPerson"/> types for non-equality.
        /// </summary>
        /// <param name="a"><see cref="TripPerson"/> A.</param>
        /// <param name="b"><see cref="TripPerson"/> B.</param>
        /// <returns><c>true</c> indicates not equal; otherwise, <c>false</c> for equal.</returns>
        public static bool operator != (TripPerson? a, TripPerson? b) => !Equals(a, b);

        /// <summary>
        /// Returns a hash code for the <see cref="TripPerson"/>.
        /// </summary>
        /// <returns>A hash code for the <see cref="TripPerson"/>.</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(FirstName);
            hash.Add(LastName);
            return base.GetHashCode() ^ hash.ToHashCode();
        }
    
        #endregion
        
        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="TripPerson"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="TripPerson"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<TripPerson>(from);
            CopyFrom(fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="TripPerson"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="TripPerson"/> to copy from.</param>
        public void CopyFrom(TripPerson from)
        {
            CopyFrom((EntityBase)from);
            Id = from.Id;
            FirstName = from.FirstName;
            LastName = from.LastName;

            OnAfterCopyFrom(from);
        }
    
        #endregion
        
        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="TripPerson"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="TripPerson"/>.</returns>
        public override object Clone()
        {
            var clone = new TripPerson();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="TripPerson"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            Id = Cleaner.Clean(Id, StringTrim.UseDefault, StringTransform.UseDefault);
            FirstName = Cleaner.Clean(FirstName, StringTrim.UseDefault, StringTransform.UseDefault);
            LastName = Cleaner.Clean(LastName, StringTrim.UseDefault, StringTransform.UseDefault);

            OnAfterCleanUp();
        }
    
        /// <summary>
        /// Indicates whether considered initial; i.e. all properties have their initial value.
        /// </summary>
        /// <returns><c>true</c> indicates is initial; otherwise, <c>false</c>.</returns>
        public override bool IsInitial
        {
            get
            {
                return Cleaner.IsInitial(Id)
                    && Cleaner.IsInitial(FirstName)
                    && Cleaner.IsInitial(LastName);
            }
        }

        #endregion

        #region PartialMethods
      
        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(TripPerson from);

        #endregion
    } 

    /// <summary>
    /// Represents a <see cref="TripPerson"/> collection.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public partial class TripPersonCollection : EntityBaseCollection<TripPerson>
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TripPersonCollection"/> class.
        /// </summary>
        public TripPersonCollection(){ }

        /// <summary>
        /// Initializes a new instance of the <see cref="TripPersonCollection"/> class with an entity range.
        /// </summary>
        /// <param name="entities">The <see cref="TripPerson"/> entities.</param>
        public TripPersonCollection(IEnumerable<TripPerson> entities) => AddRange(entities);

        #endregion

        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="TripPersonCollection"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="TripPersonCollection"/>.</returns>
        public override object Clone()
        {
            var clone = new TripPersonCollection();
            foreach (TripPerson item in this)
            {
                clone.Add((TripPerson)item.Clone());
            }
                
            return clone;
        }
        
        #endregion

        #region Operator

        /// <summary>
        /// An implicit cast from a <see cref="TripPersonCollectionResult"/> to a <see cref="TripPersonCollection"/>.
        /// </summary>
        /// <param name="result">The <see cref="TripPersonCollectionResult"/>.</param>
        /// <returns>The corresponding <see cref="TripPersonCollection"/>.</returns>
        public static implicit operator TripPersonCollection(TripPersonCollectionResult result) => result?.Result!;

        #endregion
    }

    /// <summary>
    /// Represents a <see cref="TripPerson"/> collection result.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public class TripPersonCollectionResult : EntityCollectionResult<TripPersonCollection, TripPerson>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TripPersonCollectionResult"/> class.
        /// </summary>
        public TripPersonCollectionResult() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TripPersonCollectionResult"/> class with default <see cref="PagingArgs"/>.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public TripPersonCollectionResult(PagingArgs? paging) : base(paging) { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TripPersonCollectionResult"/> class with a <paramref name="collection"/> of items to add.
        /// </summary>
        /// <param name="collection">A collection containing items to add.</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public TripPersonCollectionResult(IEnumerable<TripPerson> collection, PagingArgs? paging = null) : base(paging) => Result.AddRange(collection);
        
        /// <summary>
        /// Creates a deep copy of the <see cref="TripPersonCollectionResult"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="TripPersonCollectionResult"/>.</returns>
        public override object Clone()
        {
            var clone = new TripPersonCollectionResult();
            clone.CopyFrom(this);
            return clone;
        }
    }
}

#nullable restore