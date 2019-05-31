using System;
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
        public List<SideMark> Sidemark { get; set; }
        public string Nickname { get; set; }
        public string Group { get; set; }

        public string SalesPerson { get; set; }
        
        public string Leadnumber { get; set; }
        

    }
    public class SideMark
    {
        public string SidemarkText { get; set; }
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

    #region Payment data specific classes

    public class PaymentData
    {
        public string Amount { get; set; }
        public string GiftCardNumber { get; set; }
      
        public string ExitPaymentReason { get; set; }
        public string ExitReasonDropDownValue { get; set; }
        public string ReasonDetails { get; set; }
        public string AccountName { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }
        public string CheckNumber { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public string SkippingReason { get; set; }
        public string SkippingReasonDetail { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string CVVCode { get; set; }
        public string CreditCardHolder { get; set; }
        public string WarningMessageOnRefund { get; set; }
        public string WarningMessageOnPayment { get; set; }
        public string PaymentMethod { get; set; }
        

        public List<GridRecord> GridData { get; set; }


    }

    public class GridRecord
    {
        public string Payment { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderStatus { get; set; }
        public string SalesPerson { get; set; }
        public string AmountCollected { get; set; }
        public string AmountPosted { get; set; }
        public string BalanceDue { get; set; }

    }
    #endregion

    #region Reasons specific classes

    public class ReasonsData
    {
        public string CancelReasons { get; set; }

    }

    #endregion

    #region Store specific classes

    public class StoreData
    {
        public string StoreCode { get; set; }

    }

    #endregion

    #region Search specific classes

    public class SearchData
    {
        public string OrderNumber { get; set; }
        public string QuoteNumber { get; set; }

    }

    #endregion
}
