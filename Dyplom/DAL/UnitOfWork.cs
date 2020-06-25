using System;
using System.Data.Entity;
using System.Collections.Generic;
using Dyplom.Classes;
using Dyplom.DAL.Interfaces;

namespace Dyplom.DAL
{
    /// <summary>
    /// Is used to manage repositories. 
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Contains order context instance.
        /// </summary>
        private readonly OrderContext _context;

        /// <summary>
        /// Orders field is used to manage table 'Orders' in the database.
        /// </summary>
        public GenericRepository<Order> Orders { get; }

        /// <summary>
        /// Clients field is used to manage table 'Clients' in the database.
        /// </summary>
        public GenericRepository<Corporation> Corporations { get; }


        /// <summary>
        /// A variable which shows whether context is disposed or not.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Default constructor that instantiates UnitOfWork object. 
        /// </summary>
        public UnitOfWork()
        {
            _context = new OrderContext();
            Orders = new GenericRepository<Order>(_context);
            Corporations = new GenericRepository<Corporation>(_context);
        }

        /// <summary>
        /// Retrieves all orders from database.
        /// </summary>
        /// <returns>Orders list.</returns>
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetOrder(int id)
        {
            var order = Orders.GetById(id);
            yield return order;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Corporation> GetCorp(int id)
        {
            var corporation = Corporations.GetById(id);
            yield return corporation;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Corporation> GetCorpss()
        {
            return _context.Corporations;
        }
        public Order _GetOrder(int id)
        {
            Order order = Orders.GetById(id);
            return order;
        }
        public Corporation _GetCorporation(int id)
        {
            Corporation corporation = Corporations.GetById(id);
            return corporation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Order id.</param>
        public bool DeleteOrder(int id)
        {
            try
            {
                //var order = Orders.GetById(id);
                Orders.Delete(id);
                return true;
            }
            catch { return false; }
        }
        public void DeleteCorp(int id)
        {
            var corporation = Corporations.GetById(id);
            Corporations.Delete(corporation);
        }


        /// <summary>
        /// Saves context changes.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Disposes context using disposing parameter.
        /// </summary>
        /// <param name="disposing">Sets disposing state.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        /// <summary>
        /// Implements Dispose method.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
    }
}
