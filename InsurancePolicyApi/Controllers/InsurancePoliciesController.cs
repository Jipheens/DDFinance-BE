using InsurancePolicyApi.Data;
using InsurancePolicyApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsurancePolicyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePoliciesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InsurancePoliciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<EntityResponse<IEnumerable<InsurancePolicy>>>> GetInsurancePolicies(string search = "")
        {
            try
            {
                var policies = await _context.InsurancePolicies
                    .Where(p => (string.IsNullOrEmpty(search) || p.PolicyHolderName.Contains(search) || p.PolicyNumber.Contains(search))
                                && p.DeletedFlag == "N") 
                    .ToListAsync();

                if (policies == null || policies.Count == 0)
                {
                    return NotFound(new EntityResponse<IEnumerable<InsurancePolicy>>("No policies found.", null, 404));
                }

                return Ok(new EntityResponse<IEnumerable<InsurancePolicy>>("Policies retrieved successfully.", policies, 200));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new EntityResponse<string>("An error occurred while processing your request.", ex.Message, 500));
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EntityResponse<InsurancePolicy>>> GetInsurancePolicy(int id)
        {
            try
            {
                var policy = await _context.InsurancePolicies
                    .Where(p => p.Id == id && p.DeletedFlag == "N") 
                    .FirstOrDefaultAsync();

                if (policy == null)
                {
                    return NotFound(new EntityResponse<InsurancePolicy>("Policy not found.", null, 404));
                }

                return Ok(new EntityResponse<InsurancePolicy>("Policy retrieved successfully.", policy, 200));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new EntityResponse<string>("An error occurred while processing your request.", ex.Message, 500));
            }
        }


        [HttpGet("active")]
        public async Task<ActionResult<EntityResponse<IEnumerable<InsurancePolicy>>>> GetActiveInsurancePolicies()
        {
            try
            {
                var policies = await _context.InsurancePolicies
                    .Where(p => p.DeletedFlag == "N") 
                    .ToListAsync();

                if (policies == null || policies.Count == 0)
                {
                    return NotFound(new EntityResponse<IEnumerable<InsurancePolicy>>("No active policies found.", null, 404));
                }

                return Ok(new EntityResponse<IEnumerable<InsurancePolicy>>("Active policies retrieved successfully.", policies, 200));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new EntityResponse<string>("An error occurred while processing your request.", ex.Message, 500));
            }
        }



        [HttpPost]
        public async Task<ActionResult<EntityResponse<InsurancePolicy>>> PostInsurancePolicy(InsurancePolicy policy)
        {
            try
            {
                policy.PostedTime = DateTime.UtcNow; 
                _context.InsurancePolicies.Add(policy);
                await _context.SaveChangesAsync();

                var response = new EntityResponse<InsurancePolicy>("Policy created successfully.", policy, 201);
                return CreatedAtAction(nameof(GetInsurancePolicy), new { id = policy.Id }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new EntityResponse<string>("An error occurred while creating the policy.", ex.Message, 500));
            }
        }

        
        [HttpPut]
        public async Task<IActionResult> PutInsurancePolicy(InsurancePolicy policy)
        {
            try
            {
                
                var existingPolicy = await _context.InsurancePolicies.FindAsync(policy.Id);

                if (existingPolicy == null)
                {
                    return NotFound(new EntityResponse<string>("Policy not found.", null, 404));
                }

                
                existingPolicy.PolicyNumber = policy.PolicyNumber;
                existingPolicy.PolicyHolderName = policy.PolicyHolderName;
                existingPolicy.StartDate = policy.StartDate;
                existingPolicy.EndDate = policy.EndDate;
                existingPolicy.PremiumAmount = policy.PremiumAmount;
                existingPolicy.CoverageType = policy.CoverageType;
                existingPolicy.ModifiedTime = DateTime.UtcNow;  

                
                await _context.SaveChangesAsync();

                return Ok(new EntityResponse<string>("Policy updated successfully.", null, 200));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new EntityResponse<string>("An error occurred while updating the policy.", ex.Message, 500));
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurancePolicy(int id)
        {
            try
            {
                var policy = await _context.InsurancePolicies.FindAsync(id);

                if (policy == null)
                {
                    return NotFound(new EntityResponse<string>("Policy not found.", null, 404));
                }

                policy.DeletedFlag = "Y"; 
                policy.DeletedTime = DateTime.UtcNow; 
                _context.Entry(policy).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(new EntityResponse<string>("Policy deleted successfully.", null, 200));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new EntityResponse<string>("An error occurred while deleting the policy.", ex.Message, 500));
            }
        }

    }
}