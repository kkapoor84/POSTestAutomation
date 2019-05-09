﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNDBProject.TestDataAccess
{
    public class ParsedTestData
    {
        public string Feature { get; set; }
        public List<DataDictionary> Data { get; set; }
    }

    public class DataDictionary
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }

    #region Login Data Specific Classes

    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    #endregion

    #region Customer Data Specific Classes

    public class NewCustomerData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
        public List<Address> Addresses { get; set; }
        public List<TaxNumber> TaxNumbers { get; set; }
    }


    public class UpdateCustomerData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
        public List<Address> Addresses { get; set; }
        public List<TaxNumber> TaxNumbers { get; set; }
    }


    public class Phone
    {
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
    }

    public class Email
    {
        public string EmailText { get; set; }
    }

    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class TaxNumber
    {
        public string TaxIdNumber { get; set; }
        public string TaxState { get; set; }
    }

    #endregion

    #region Product Line data specific classes

    public class ProductLineData
    {
        public string Width { get; set; }
        public string Height { get; set; }
        public string NDBRoomLocation { get; set; }
        public string Quantity { get; set; }
        public string ProductType { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }


    public class ProductDetail
    {
        public string OptionTypeId { get; set; }
        public string Option { get; set; }
    }


    public class EditProductLineData
    {
        public string NDBRoomLocation { get; set; }
        public List<EditProductDetail> EditProductDetails { get; set; }
    }

    public class EditProductDetail
    {
        public string OptionTypeId { get; set; }
        public string Option { get; set; }
    }

    #endregion

    #region Internal Info data specific classes
    public class InternalInfoData
    {
        public string StoreCode { get; set; }
        public string Sidemark { get; set; }
        public string Nickname { get; set; }
    }


    #endregion

    #region Measurement and Installation data specific classes

    public class MeasurementAndInstallationData
    {
        public string Directions { get; set; }
        public Boolean SelectLadder { get; set; }
        public string MeasurementNotes { get; set; }
        public Boolean AddAdditionalCost { get; set; }
        public string AdditionalCostAmount { get; set; }
        public string AdditionalCostReason { get; set; }
        public Boolean AddAdditionalMin { get; set; }
        public string AdditionalMinAmount { get; set; }
        public string AdditionalMinReason { get; set; }
        public string InstallerNotes { get; set; }

    }
    #endregion

    #region Adjustment data specific classes


    public class AdjustmentData
    {
        public List<Adjustment> Adjustments { get; set; }
        public string AdjustmentTotalAmount { get; set; }


    }

    public class Adjustment
    {
        public string AdjustmentType { get; set; }
        public string AdjustmentCode { get; set; }
        public string Amount { get; set; }
    }

    #endregion

    #region Tax data specific classes

    public class TaxExemptionData
    {
        public string TaxIdNumber { get; set; }
        public Boolean ApplyTaxExempt { get; set; }
        public string ExemptTax { get; set; }
        
    }

    #endregion

    #region Reasons specific classes

    public class ReasonsData
    {
        public string CancelReasons { get; set; }

    }

    #endregion
}
