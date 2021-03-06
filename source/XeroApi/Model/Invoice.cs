﻿using System;

namespace XeroApi.Model
{
    public class Invoice : ModelBase
    {
        [ItemId]
        public virtual Guid InvoiceID { get; set; }

        [ItemNumber]
        public string InvoiceNumber { get; set; }

        [ItemUpdatedDate]
        public DateTime? UpdatedDateUTC { get; set; }

        public string Type { get; set; }

        public string Reference { get; set; }

        public Payments Payments { get; set; }

        public CreditNotes CreditNotes { get; set; }

        public decimal? AmountDue { get; set; }

        public decimal? AmountPaid { get; set; }

        public decimal? AmountCredited { get; set; }
        
        public string Url { get; set; }

        public string ExternalLinkProviderName { get; set; }

        public bool? SentToContact { get; set; }

        public decimal? CurrencyRate { get; set; }

        public Contact Contact { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? DueDate { get; set; }

        public virtual Guid? BrandingThemeID { get; set; }

        public virtual string Status { get; set; }

        public LineAmountType LineAmountTypes { get; set; }

        public virtual LineItems LineItems { get; set; }

        public virtual decimal? SubTotal { get; set; }

        public virtual decimal? TotalTax { get; set; }

        public virtual decimal? Total { get; set; }

        public virtual string CurrencyCode { get; set; }

        public DateTime? FullyPaidOnDate { get; set; }
    }
   
   
    public class Invoices : ModelList<Invoice>
    {
    }
}