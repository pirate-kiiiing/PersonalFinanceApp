﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PirateKing.Constants;
using PirateKing.Core;

namespace PirateKing.Guards
{
    public class Validate
    {
        /// <summary>
        /// Guards against a null or an empty string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputName"></param>
        public static void NotNullOrEmpty(string value, string inputName)
        {
            if (value == null) throw new ArgumentNullException(Errors.NullExceptionMessage(value, inputName));
            if (String.IsNullOrWhiteSpace(value) == true) throw new ArgumentException(Errors.InvalidMessage(value, inputName));
        }

        /// <summary>
        /// Guards against a null or an empty collection
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputName"></param>
        public static void NotNullOrEmpty<T>(IEnumerable<T> value, string inputName)
        {
            if (value == null) throw new ArgumentNullException(Errors.NullExceptionMessage(value, inputName));
            if (value.Count() <= 0) throw new ArgumentException(Errors.InvalidMessage(value, inputName));
        }

        /// <summary>
        /// Guards against a null or an empty collection
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputName"></param>
        public static void NotNullOrEmpty(ICollection value, string inputName)
        {
            if (value == null) throw new ArgumentNullException(Errors.NullExceptionMessage(value, inputName));
            if (value.Count <= 0) throw new ArgumentException(Errors.InvalidMessage(value, inputName));
        }

        /// <summary>
        /// Guards against an empty Guid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputName"></param>
        public static void NotEmpty(Guid value, string inputName)
        {
            if (value == Guid.Empty) throw new ArgumentException(Errors.InvalidMessage(value, inputName));
        }

        /// <summary>
        /// Guards against a null object
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputName"></param>
        public static void NotNull(object value, string inputName)
        {
            if (value == null) throw new ArgumentNullException(Errors.NullExceptionMessage(value, inputName));
        }

        /// <summary>
        /// Guards against a non-null or a non-empty string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputName"></param>
        public static void IsNullOrEmpty(string value, string inputName)
        {
            if (value != null && String.IsNullOrWhiteSpace(value) == true)
                throw new ArgumentException(Errors.InvalidMessage(value, inputName));
        }

        /// <summary>
        /// Guards against non-existing key in a dictionary
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dictionaryName"></param>
        public static void ContainsKey<K, T>(IDictionary<K, T> value, K key, string dictionaryName, string keyName)
        {
            NotNullOrEmpty(value as ICollection, dictionaryName);
            if (value.ContainsKey(key) == false) throw new ArgumentException($"{dictionaryName} does not contain key {keyName}");
        }

        public static void ValidDateTime(string _dateTime)
        {
            if (DateTime.TryParse(_dateTime, out DateTime dateTime) == false)
            {
                throw new ArgumentException($"Invalid {nameof(dateTime)} {_dateTime}");
            }
        }

        public static void ValidRange(DateTime startDate, DateTime endDate)
        {
            if (startDate == DateTime.MinValue) throw new ArgumentOutOfRangeException(Errors.InvalidMessage(startDate, nameof(startDate)));
            if (endDate == DateTime.MinValue) throw new ArgumentOutOfRangeException(Errors.InvalidMessage(endDate, nameof(endDate)));
            if (startDate > endDate) throw new ArgumentException($"{nameof(startDate)} cannot be later than {nameof(endDate)}");
        }

        public static void ValidRange(Date startDate, Date endDate)
        {
            NotNull(startDate, nameof(startDate));
            NotNull(endDate, nameof(endDate));
            ValidRange(startDate.ToDateTime(), endDate.ToDateTime());
        }

        public static void ValidRange(string startDate, string endDate)
        {
            ValidDateTime(startDate);
            ValidDateTime(endDate);
            ValidRange(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
        }

        public static void DateFormatYmd(string date)
        {
            if (DateTime.TryParseExact(date, DateFormats.DateYmd, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt) == false)
            {
                throw new ArgumentException(Errors.InvalidMessage(date, nameof(date)));
            }
            else if (dt.Year < 1900 || dt.Year > 2099)
            {
                throw new ArgumentOutOfRangeException(Errors.InvalidMessage(date, nameof(date)));
            }
        }
    }
}
