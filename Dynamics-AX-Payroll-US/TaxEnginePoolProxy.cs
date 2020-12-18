// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Symmetry.TaxEngine;

namespace Microsoft.Dynamics.AX.Application.HumanCapitalManagement.Payroll
{
    /// <summary>
    /// Provides singleton access to the tax engine object pool.
    /// </summary>
    public class TaxEnginePoolProxy
    {
        const string taxEngineDirectory = "STE";

        private static volatile TaxEnginePoolProxy taxEnginePool;
        private static object syncRoot = new Object();

        private Symmetry.TaxEngine.STEObjectPool pool;

        /// <summary>
        /// Initializes the tax engine pool.
        /// </summary>
        private TaxEnginePoolProxy()
        {
            // The STE directory will always be within the server's bin folder that contains the current assembly
            String path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), taxEngineDirectory);

            // The last four parameters specify initialization of the pool:
            //   numInitialObjects: the initial number of objects to create for the pool
            //   recycleTime:       the number of seconds before an object in the pool is destroyed later to be replaced with a newly created object. 
            //                      If set to zero, objects are never destroyed.    
            //   forceRecoverTime:  the number of seconds before an object which has not been checked in is destroyed. Zero disbles forced recovery.
            //   maxObjects:        the maximum number of objects you want in the pool. If set to zero, no maximum number is enforced and no blocking occurs.
            pool = new STEObjectPool(path, 1, 0, 0, 0);
        }

        /// <summary>
        /// Checks a tax engine instance out of the current object pool and returns it.
        /// </summary>
        /// <returns>Returns a tax engine instance that has been checked out of the current object pool.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        public Symmetry.TaxEngine.STEPayrollCalculator checkOutTaxEngine()
        {
            return pool.checkOut();
        }

        /// <summary>
        /// Checks the provided tax engine instance back into the object pool to potentially be used again.
        /// </summary>
        /// <param name="taxEngine"></param>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        public void checkInTaxEngine(Symmetry.TaxEngine.STEPayrollCalculator taxEngine)
        {
            pool.checkIn(taxEngine);
        }

        /// <summary>
        /// Retrieves a singleton TaxEnginePoolProxy instance.
        /// </summary>
        public static TaxEnginePoolProxy TaxEnginePool
        {
            get
            {
                if (taxEnginePool == null)
                {
                    lock (syncRoot)
                    {
                        if (taxEnginePool == null)
                            taxEnginePool = new TaxEnginePoolProxy();
                    }
                }

                return taxEnginePool;
            }
        }
    }
}
