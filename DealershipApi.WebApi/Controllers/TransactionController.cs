﻿using DealershipApi.Models.DisplayModels.Transaction;
using DealershipApi.Models.DisplayModels.Vehicle;
using DealershipApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DealershipApi.WebApi.Controllers
{
   // [Authorize]
    public class TransactionController : ApiController
    {
        private TransactionService CreateTransactionService()
        {

            var transactionService = new TransactionService();
            return transactionService;
        }

        public IHttpActionResult Get()
        {
            TransactionService transactionService = CreateTransactionService();
            var transaction = transactionService.GetTransactions();
            return Ok(transaction);
        }

        public IHttpActionResult Post(VehicleCreate vehicle, TransactionPurchaseCreate transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTransactionService();

            if (!service.CreatePurchaseTransaction(vehicle, transaction))
            {
                return InternalServerError();
            }

            return Ok();
        }

     
        public IHttpActionResult Get(int id)
        {
            TransactionService transactionService = CreateTransactionService();
            var transaction = transactionService.GetTransactionById(id);
            return Ok(transaction);
        }

        public IHttpActionResult Put(TransactionEdit transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTransactionService();

            if (!service.UpdateTransaction(transaction))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpPost]
        // [Route("api/Transfer/{int: dealershipId}")]
        public IHttpActionResult Transfer([FromBody]TransactionPurchaseCreate transactionId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTransactionService();

            if (!service.CreateTransferTransaction(transactionId))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Sale(TransactionPurchaseCreate sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTransactionService();
            
            if (!service.CreateSaleTransaction(sale))
            {
                return InternalServerError();
            }

            return Ok("Good sale!");
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTransactionService();

            if (!service.DeleteTransaction(id))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
