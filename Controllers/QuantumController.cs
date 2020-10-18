
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using QuantumWebAPI.Models;
using QuantumWebAPI.Repositories;
using System.Web.Http.Description;

namespace QuantumWebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class QuantumController :ApiController
    {

        private readonly IQuantumRepository _iQuantumRepository;

        /// <summary>
        /// 
        /// </summary>
        public QuantumController()
        {
            _iQuantumRepository = new QuantumRepository();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuantumRepository"></param>
        public QuantumController(IQuantumRepository iQuantumRepository)
        {
            _iQuantumRepository = iQuantumRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPartNumberTodayHits")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetPartNumberTodayHits()
        {
            try
            {
                var result = _iQuantumRepository.GetPartNumberTodayHits();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch(Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPartNumber30DayHits")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetPartNumber30DayHits()
        {
            try
            {
                var result = _iQuantumRepository.GetPartNumber30DayHits();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSalesOrdersFeed")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetSalesOrdersFeed()
        {
            try
            {
                var result = _iQuantumRepository.GetSalesOrdersFeed();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQuoteFeeds")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetQuoteFeeds()
        {
            try
            {
                var result = _iQuantumRepository.GetQuoteFeeds();

                result = result.OrderByDescending(q => q.Date.TimeOfDay).ToList();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmployeeTodayQuotes")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetEmployeeTodayQuotes()
        {
            try
            {
                var result = _iQuantumRepository.GetEmployeeTodayQuotes();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmployeeMTDQuotes")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetEmployeeMTDQuotes()
        {
            try
            {
                var result = _iQuantumRepository.GetEmployeeMTDQuotes();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }





        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmployeeTodaySalesOrders")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetEmployeeTodaySalesOrders()
        {
            try
            {
                var result = _iQuantumRepository.GetEmployeeTodaySalesOrders();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmployeeMTDSalesOrders")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetEmployeeMTDSalesOrders()
        {
            try
            {
                var result = _iQuantumRepository.GetEmployeeMTDSalesOrders();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPurchaseOrderTotals")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetPurchaseOrderTotals()
        {
            try
            {
                var result = _iQuantumRepository.GetPurchaseOrderTotals();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRepairOrderTotals")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetRepairOrderTotals()
        {
            try
            {
                var result = _iQuantumRepository.GetRepairOrderTotals();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSalesOrderTotals")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetSalesOrderTotals()
        {
            try
            {
                var result = _iQuantumRepository.GetSalesOrderTotals();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInvoiceTotals")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetInvoiceTotals()
        {
            try
            {
                var result = _iQuantumRepository.GetInvoiceTotals();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSaleOrderToQuoteRatios")]
        [ResponseType(typeof(ApiResponse))]
        public HttpResponseMessage GetSaleOrderToQuoteRatios()
        {
            try
            {
                var result = _iQuantumRepository.GetSaleOrderToQuoteRatios();

                if (result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                ApiResponse responseclass = new ApiResponse(true, "SUCCESS", result);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.OK, responseclass);
                return response;
            }

            catch (Exception ex)
            {
                ApiResponse responseclass = new ApiResponse(false, ex.Message, null);
                HttpResponseMessage response = Request.CreateResponse<ApiResponse>(HttpStatusCode.NotFound, responseclass);
                return response;
            }
        }


    }
}
