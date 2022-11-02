﻿using System;

namespace PirateKing.Configurations
{
    public abstract class EnvironmentDefinition
    {
        /// <summary>
        /// KeyVault Configuration
        /// </summary>
        public abstract ClientConfiguration KeyVaultConfiguration { get; }

        /// <summary>
        /// Plaid Configuration
        /// </summary>
        public abstract PlaidConfiguration PlaidConfiguration { get; }


        public static string GetEnvironment()
        {
            string environment = Environment.GetEnvironmentVariable(nameof(Environment));

            if (string.IsNullOrEmpty(environment) == true)
            {
                return EnvironmentConstants.Production;
            }

            return environment.ToLowerInvariant();
        }

        public static EnvironmentDefinition GetEnvironmentDefinition()
        {
            string environment = GetEnvironment();

            if (string.IsNullOrEmpty(environment) == true)
            {
                throw new ArgumentNullException(nameof(environment), "Current environment is not defined in config settings");
            }

            switch (environment)
            {
                //case EnvironmentConstants.Local:
                //    return new LocalEnvironmentDefinition();

                case EnvironmentConstants.Production:
                    return new ProductionEnvironmentDefinition();
            }

            throw new InvalidOperationException("Invalid environment");
        }
    }
}
