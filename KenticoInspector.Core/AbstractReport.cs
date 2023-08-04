﻿using System;
using System.Collections.Generic;

using KenticoInspector.Core.Models;
using KenticoInspector.Core.Services.Interfaces;

namespace KenticoInspector.Core
{
    public abstract class AbstractReport<T> : IReport, IWithMetadata<T> where T : new()
    {
        protected readonly IReportMetadataService reportMetadataService;

        private ReportMetadata<T> metadata;

        protected AbstractReport(IReportMetadataService reportMetadataService)
        {
            this.reportMetadataService = reportMetadataService;
        }

        public string Codename => GetCodename(this.GetType());

        public abstract IList<Version> CompatibleVersions { get; }

        /// <summary>
        /// Set to <c>true</c> if the report modifies any data. If <c>true</c>, the report
        /// appears in the "Tools" menu of the UI.
        /// </summary>
        public abstract bool ModifiesData { get; }

        public virtual IList<Version> IncompatibleVersions => new List<Version>();

        public ReportMetadata<T> Metadata
        {
            get
            {
                return metadata ?? (metadata = reportMetadataService.GetReportMetadata<T>(Codename));
            }
        }

        public abstract IList<string> Tags { get; }

        public static string GetCodename(Type reportType)
        {
            return GetDirectParentNamespace(reportType);
        }

        public abstract ReportResults GetResults();

        private static string GetDirectParentNamespace(Type reportType)
        {
            var fullNameSpace = reportType.Namespace;
            var indexAfterLastPeriod = fullNameSpace.LastIndexOf('.') + 1;

            return fullNameSpace.Substring(indexAfterLastPeriod, fullNameSpace.Length - indexAfterLastPeriod);
        }
    }
}