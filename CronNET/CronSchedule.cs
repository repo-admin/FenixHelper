using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fenix.CronNET
{
    /// <summary>
	/// Plánovaè úloh
	/// </summary>
    public class CronSchedule : ICronSchedule
    {
        #region Readonly Class Members

        static readonly Regex _dividedRegex = new Regex(@"(\*/\d+)");
        static readonly Regex _rangeRegex = new Regex(@"(\d+\-\d+)\/?(\d+)?");
        static readonly Regex _wildRegex = new Regex(@"(\*)");
        static readonly Regex _listRegex = new Regex(@"(((\d+,)*\d+)+)");
        static readonly Regex _validationRegex = new Regex(_dividedRegex + "|" + _rangeRegex + "|" + _wildRegex + "|" + _listRegex);

        #endregion

        #region Private Instance Members

        private readonly string _expression;

		/// <summary>
		/// 
		/// </summary>
        public List<int> Minutes;

		/// <summary>
		/// 
		/// </summary>
        public List<int> Hours;

		/// <summary>
		/// 
		/// </summary>
        public List<int> DaysOfMonth;

		/// <summary>
		/// 
		/// </summary>
        public List<int> Months;

		/// <summary>
		/// 
		/// </summary>
        public List<int> DaysOfWeek;

        #endregion

        #region Public Constructors

		/// <summary>
		/// ctor
		/// </summary>
        public CronSchedule()
        {
        }

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="expressions"></param>
        public CronSchedule(string expressions)
        {
            this._expression = expressions;
            Generate();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Validuje výraz, pøedaný do instance tøídy v konstruktoru
        /// </summary>
        /// <returns></returns>
        private bool IsValidInternal()
        {
            return IsValid(this._expression);
        }

		/// <summary>
		/// Vrácí stav validace pro specifikovaný výraz
		/// </summary>
		/// <param name="expression">Výraz, který se bude validovat</param>
		/// <returns></returns>
        public bool IsValid(string expression)
        {
            MatchCollection matches = _validationRegex.Matches(expression);
            return matches.Count > 0;//== 5;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
        public bool IsTime(DateTime dateTime)
        {
            return Minutes.Contains(dateTime.Minute) &&
                   Hours.Contains(dateTime.Hour) &&
                   DaysOfMonth.Contains(dateTime.Day) &&
                   Months.Contains(dateTime.Month) &&
                   DaysOfWeek.Contains((int)dateTime.DayOfWeek);
        }

        /// <summary>
        /// Generuje rozpad specifikovaného výrazu na jednotlivé èasové intervaly
        /// </summary>
        private void Generate()
        {
            if (!IsValidInternal()) return;

            MatchCollection matches = _validationRegex.Matches(this._expression);

            GenerateMinutes(matches[0].ToString());

            if (matches.Count > 1)
                GenerateHours(matches[1].ToString());
            else
                GenerateHours("*");
            
            if (matches.Count > 2)
                GenerateDaysOfMonth(matches[2].ToString());
            else
                GenerateDaysOfMonth("*");
            
            if (matches.Count > 3)
                GenerateMonths(matches[3].ToString());
            else
                GenerateMonths("*");
            
            if (matches.Count > 4)
                GenerateDaysOfWeeks(matches[4].ToString());
            else
                GenerateDaysOfWeeks("*");
        }

        /// <summary>
        /// Generuje hodnotu <see cref="CronSchedule.Minutes"/>
        /// </summary>
        /// <param name="match">Výraz k parsování</param>
        private void GenerateMinutes(string match)
        {
            this.Minutes = GenerateValues(match, 0, 60);
        }

        /// <summary>
        /// Generuje hodnotu <see cref="CronSchedule.Hours"/>
        /// </summary>
        /// <param name="match"></param>
        private void GenerateHours(string match)
        {
            this.Hours = GenerateValues(match, 0, 24);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        private void GenerateDaysOfMonth(string match)
        {
            this.DaysOfMonth = GenerateValues(match, 1, 32);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        private void GenerateMonths(string match)
        {
            this.Months = GenerateValues(match, 1, 13);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        private void GenerateDaysOfWeeks(string match)
        {
            this.DaysOfWeek = GenerateValues(match, 0, 7);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="start"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private List<int> GenerateValues(string configuration, int start, int max)
        {
            if (_dividedRegex.IsMatch(configuration)) return DividedArray(configuration, start, max);
            if (_rangeRegex.IsMatch(configuration)) return RangeArray(configuration);
            if (_wildRegex.IsMatch(configuration)) return WildArray(configuration, start, max);
            if (_listRegex.IsMatch(configuration)) return ListArray(configuration);

            return new List<int>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="start"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private List<int> DividedArray(string configuration, int start, int max)
        {
            if (!_dividedRegex.IsMatch(configuration))
                return new List<int>();

            List<int> ret = new List<int>();
            string[] split = configuration.Split("/".ToCharArray());
            int divisor = int.Parse(split[1]);

            for (int i = start; i < max; ++i)
                if (i % divisor == 0)
                    ret.Add(i);

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        private List<int> RangeArray(string configuration)
        {
            if (!_rangeRegex.IsMatch(configuration))
                return new List<int>();

            List<int> ret = new List<int>();
            string[] split = configuration.Split("-".ToCharArray());
            int start = int.Parse(split[0]);
            int end = 0;
            if (split[1].Contains("/"))
            {
                split = split[1].Split("/".ToCharArray());
                end = int.Parse(split[0]);
                int divisor = int.Parse(split[1]);

                for (int i = start; i < end; ++i)
                    if (i % divisor == 0)
                        ret.Add(i);
                return ret;
            }
            else
                end = int.Parse(split[1]);

            for (int i = start; i <= end; ++i)
                ret.Add(i);

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="start"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private List<int> WildArray(string configuration, int start, int max)
        {
            if (!_wildRegex.IsMatch(configuration))
                return new List<int>();

            List<int> ret = new List<int>();

            for (int i = start; i < max; ++i)
                ret.Add(i);

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        private List<int> ListArray(string configuration)
        {
            if (!_listRegex.IsMatch(configuration))
                return new List<int>();

            List<int> ret = new List<int>();

            string[] split = configuration.Split(",".ToCharArray());

            foreach (string s in split)
                ret.Add(int.Parse(s));

            return ret;
        }

        #endregion
    }
}
