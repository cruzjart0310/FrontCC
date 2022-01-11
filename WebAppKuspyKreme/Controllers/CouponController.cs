using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebAppKuspyKreme.Models;
using X.PagedList;
using OfficeOpenXml;
using System.Threading.Tasks;
//using OfficeOpenXml.Core.ExcelPackage;

namespace WebAppKuspyKreme.Controllers
{
    public class CouponController : Controller
    {
        private HttpClient httpClient;
        public string urlBase;

        public CouponController()
        {
            httpClient = new HttpClient();
            urlBase = "http://localhost:60861/Service.svc/";
        }

        // GET: Coupon
        public async Task<ActionResult> Index(int? page = 1)
        {
            try
            {
                var responseApi = await httpClient.GetAsync($"{urlBase}/coupons");
                if (responseApi.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string response = await responseApi.Content.ReadAsStringAsync();
                    var parseResponse = JsonConvert.DeserializeObject<ResponseBase<Coupon>>(response);

                    if (parseResponse.Success && parseResponse.List != null)
                    {
                        int pageNumber = (page ?? 1);
                        var onePageOfStudents = parseResponse.List.ToPagedList(pageNumber, 12);
                        ViewBag.PageList = onePageOfStudents;
                        return View(onePageOfStudents);
                    }
                    else
                    {
                        ViewBag.Error = parseResponse.Messaje;
                        return View("Error");
                    }
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View("Error");
            }

            return View();

        }

        // GET: Coupon/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var responseApi = await httpClient.GetAsync($"{urlBase}/coupons/{id}");
                if (responseApi.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string response = await responseApi.Content.ReadAsStringAsync();
                    var parseResponse = JsonConvert.DeserializeObject<ResponseBase<Coupon>>(response);

                    if (parseResponse.Success && parseResponse.Element != null)
                    {
                        return View(parseResponse.Element);
                    }
                    else
                    {
                        ViewBag.Error = parseResponse.Messaje;
                        return View("Error");
                    }
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View("Error");
            }

            return View();
        }

        // GET: Coupon/Create
        public ActionResult Create()
        {
            ViewBag.ListEstablishment = Utils.Util.GetEstablishments().ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.ListStatus = Utils.Util.GetEstatus().ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            Coupon coupon = new Coupon()
            {
                Serie = Utils.Util.GenerateGuid(7)
            };

            return View(coupon);
        }

        // POST: Coupon/Create
        [HttpPost]
        public async Task<ActionResult> Create(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(coupon), Encoding.UTF8, "application/json");
                    var responseApi = await httpClient.PostAsync($"{urlBase}/coupons", content);

                    if (responseApi.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string response = await responseApi.Content.ReadAsStringAsync();
                        var parseResponse = JsonConvert.DeserializeObject<ResponseBase<Coupon>>(response);

                        if (parseResponse.Success)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Error = parseResponse.Messaje;
                            return View("Error");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.ToString();
                    return View("Error");
                }
            }

            return View();
        }

        // GET: Coupon/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.ListEstablishment = Utils.Util.GetEstablishments().ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.ListStatus = Utils.Util.GetEstatus().ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            try
            {
                var responseApi = await httpClient.GetAsync($"{urlBase}/coupons/{id}");
                if (responseApi.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string response = await responseApi.Content.ReadAsStringAsync();
                    var parseResponse = JsonConvert.DeserializeObject<ResponseBase<Coupon>>(response);

                    if (parseResponse.Success && parseResponse.Element != null)
                    {
                        return View(parseResponse.Element);
                    }
                    else
                    {
                        ViewBag.Error = parseResponse.Messaje;
                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View("Error");
            }

            return View();
        }

        // POST: Coupon/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Coupon coupon)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(coupon), Encoding.UTF8, "application/json");
                var responseApi = await httpClient.PutAsync($"{urlBase}/coupons/{id}", content);

                if (responseApi.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string response = await responseApi.Content.ReadAsStringAsync();
                    var parseResponse = JsonConvert.DeserializeObject<ResponseBase<Coupon>>(response);

                    if (parseResponse.Success)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Error = parseResponse.Messaje;
                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View("Error");
            }

            return View();
        }

        // GET: Coupon/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var responseApi = await httpClient.GetAsync($"{urlBase}/coupons/{id}");
                if (responseApi.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string response = await responseApi.Content.ReadAsStringAsync();
                    var parseResponse = JsonConvert.DeserializeObject<ResponseBase<Coupon>>(response);

                    if (parseResponse.Success && parseResponse.Element != null)
                    {
                        return View(parseResponse.Element);
                    }
                    else
                    {
                        ViewBag.Error = parseResponse.Messaje;
                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View("Error");
            }

            return View();
        }

        // POST: Coupon/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                var responseApi = await httpClient.DeleteAsync($"{urlBase}/coupons/{id}");
                if (responseApi.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string response = await responseApi.Content.ReadAsStringAsync();
                    var parseResponse = JsonConvert.DeserializeObject<ResponseBase<Coupon>>(response);

                    if (parseResponse.Success)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Error = parseResponse.Messaje;
                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View("Error");
            }

            return View();
        }

        // GET: Coupon/Create
        public async Task<ActionResult> ExchangeGet(int id)
        {
            try
            {
                var request = await httpClient.GetStringAsync($"{urlBase}/coupons/{id}");
                string responseApi = request.ToString();
                var response = JsonConvert.DeserializeObject<ResponseBase<Coupon>>(responseApi);

                return View(response.Element);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View("Error");
            }
        }

        // POST: Coupon/Edit/5
        //[HttpPost]
        public async Task<ActionResult> ExchangePut(int id)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");
                var responseApi = await httpClient.PutAsync($"{urlBase}/coupons/{id}/exchange", content);

                if (responseApi.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string response = await responseApi.Content.ReadAsStringAsync();
                    var parseResponse = JsonConvert.DeserializeObject<ResponseBase<Coupon>>(response);

                    if (parseResponse.Success)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Error = parseResponse.Messaje;
                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View("Error");
            }

            return View();
        }

        public void DownloadExcel()
        {
            var request = httpClient.GetStringAsync($"{urlBase}/coupons").Result;
            string responseApi = request.ToString();
            var data = JsonConvert.DeserializeObject<ResponseBase<Coupon>>(responseApi);

            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "Id";
            Sheet.Cells["B1"].Value = "Description";
            Sheet.Cells["C1"].Value = "Duration";
            Sheet.Cells["C1"].Value = "Establishment";
            Sheet.Cells["E1"].Value = "Estatus";
            Sheet.Cells["F1"].Value = "Creation Date";
            int row = 2;

            foreach (var item in data.List)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = item.Id;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.Description;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.Duration;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.Establishment.Name;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.Status.Name;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.CreatedAt;
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
        }
    }
}
