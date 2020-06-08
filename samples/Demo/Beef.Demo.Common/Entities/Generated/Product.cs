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
    /// Represents the Product entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class Product : EntityBase, IEquatable<Product>
    {
        #region Privates

        private int _id;
        private string? _name;
        private string? _description;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="Product"/> identifier.
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        [Display(Name="Identifier")]
        public int Id
        {
            get => _id;
            set => SetValue(ref _id, value, true, false, nameof(Id)); 
        }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Name")]
        public string? Name
        {
            get => _name;
            set => SetValue(ref _name, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(Name)); 
        }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Description")]
        public string? Description
        {
            get => _description;
            set => SetValue(ref _description, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(Description)); 
        }

        #endregion

        #region UniqueKey
      
        /// <summary>
        /// Indicates whether the <see cref="Product"/> has a <see cref="UniqueKey"/> value.
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
        public static UniqueKey CreateUniqueKey(int id) => new UniqueKey(id);
          
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
            if (obj == null || !(obj is Product val))
                return false;

            return Equals(val);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Product"/> is equal to the current <see cref="Product"/> by comparing the values of all the properties.
        /// </summary>
        /// <param name="value">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public bool Equals(Product? value)
        {
            if (((object)value!) == ((object)this))
                return true;
            else if (((object)value!) == null)
                return false;

            return base.Equals((object)value)
                && Equals(Id, value.Id)
                && Equals(Name, value.Name)
                && Equals(Description, value.Description);
        }

        /// <summary>
        /// Compares two <see cref="Product"/> types for equality.
        /// </summary>
        /// <param name="a"><see cref="Product"/> A.</param>
        /// <param name="b"><see cref="Product"/> B.</param>
        /// <returns><c>true</c> indicates equal; otherwise, <c>false</c> for not equal.</returns>
        public static bool operator == (Product? a, Product? b) => Equals(a, b);

        /// <summary>
        /// Compares two <see cref="Product"/> types for non-equality.
        /// </summary>
        /// <param name="a"><see cref="Product"/> A.</param>
        /// <param name="b"><see cref="Product"/> B.</param>
        /// <returns><c>true</c> indicates not equal; otherwise, <c>false</c> for equal.</returns>
        public static bool operator != (Product? a, Product? b) => !Equals(a, b);

        /// <summary>
        /// Returns a hash code for the <see cref="Product"/>.
        /// </summary>
        /// <returns>A hash code for the <see cref="Product"/>.</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Description);
            return base.GetHashCode() ^ hash.ToHashCode();
        }
    
        #endregion
        
        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="Product"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="Product"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<Product>(from);
            CopyFrom(fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="Product"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="Product"/> to copy from.</param>
        public void CopyFrom(Product from)
        {
            CopyFrom((EntityBase)from);
            Id = from.Id;
            Name = from.Name;
            Description = from.Description;

            OnAfterCopyFrom(from);
        }
    
        #endregion
        
        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="Product"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="Product"/>.</returns>
        public override object Clone()
        {
            var clone = new Product();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="Product"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            Name = Cleaner.Clean(Name, StringTrim.UseDefault, StringTransform.UseDefault);
            Description = Cleaner.Clean(Description, StringTrim.UseDefault, StringTransform.UseDefault);

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
                return Cleaner.IsInitial(Name)
                    && Cleaner.IsInitial(Description);
            }
        }

        #endregion

        #region PartialMethods
      
        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(Product from);

        #endregion
    } 

    /// <summary>
    /// Represents a <see cref="Product"/> collection.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public partial class ProductCollection : EntityBaseCollection<Product>
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollection"/> class.
        /// </summary>
        public ProductCollection(){ }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollection"/> class with an entity range.
        /// </summary>
        /// <param name="entities">The <see cref="Product"/> entities.</param>
        public ProductCollection(IEnumerable<Product> entities) => AddRange(entities);

        #endregion

        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="ProductCollection"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="ProductCollection"/>.</returns>
        public override object Clone()
        {
            var clone = new ProductCollection();
            foreach (Product item in this)
            {
                clone.Add((Product)item.Clone());
            }
                
            return clone;
        }
        
        #endregion

        #region Operator

        /// <summary>
        /// An implicit cast from a <see cref="ProductCollectionResult"/> to a <see cref="ProductCollection"/>.
        /// </summary>
        /// <param name="result">The <see cref="ProductCollectionResult"/>.</param>
        /// <returns>The corresponding <see cref="ProductCollection"/>.</returns>
        public static implicit operator ProductCollection(ProductCollectionResult result) => result?.Result!;

        #endregion
    }

    /// <summary>
    /// Represents a <see cref="Product"/> collection result.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public class ProductCollectionResult : EntityCollectionResult<ProductCollection, Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollectionResult"/> class.
        /// </summary>
        public ProductCollectionResult() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollectionResult"/> class with default <see cref="PagingArgs"/>.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public ProductCollectionResult(PagingArgs? paging) : base(paging) { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollectionResult"/> class with a <paramref name="collection"/> of items to add.
        /// </summary>
        /// <param name="collection">A collection containing items to add.</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public ProductCollectionResult(IEnumerable<Product> collection, PagingArgs? paging = null) : base(paging) => Result.AddRange(collection);
        
        /// <summary>
        /// Creates a deep copy of the <see cref="ProductCollectionResult"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="ProductCollectionResult"/>.</returns>
        public override object Clone()
        {
            var clone = new ProductCollectionResult();
            clone.CopyFrom(this);
            return clone;
        }
    }
}

#nullable restore