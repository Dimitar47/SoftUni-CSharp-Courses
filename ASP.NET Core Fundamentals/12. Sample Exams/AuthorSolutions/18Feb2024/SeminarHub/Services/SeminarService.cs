using Microsoft.EntityFrameworkCore;
using SeminarHub.Contracts;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using System.Globalization;

namespace SeminarHub.Services
{
    public class SeminarService : ISeminarService
    {
        private readonly SeminarHubDbContext _context;

        public SeminarService(SeminarHubDbContext context)
        {
            _context = context;
        }

        public async Task AddSeminarAsync(AddSeminarViewModel seminar, string userId)
        {
            string dateTimeString = $"{seminar.DateAndTime}";

            if (!DateTime.TryParseExact(dateTimeString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
            {
                throw new InvalidOperationException("Invalid date or time format");
            }

            var newSeminar = new Seminar
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Details = seminar.Details,
                OrganizerId = userId,
                DateAndTime = parsedDateTime,
                Duration = seminar.Duration.Value,
                CategoryId = seminar.CategoryId
            };

            await _context.Seminars.AddAsync(newSeminar);
            await _context.SaveChangesAsync();
        }

        public async Task AddSeminarToJoinedAsync(string userId, JoinSeminarViewModel seminar)
        {
            bool alreadyAdded = await _context.SeminarsParticipants
                .AnyAsync(sp => sp.ParticipantId == userId && sp.SeminarId == seminar.Id);

            if (alreadyAdded == false)
            {
                var seminarParticipant = new SeminarParticipant
                {
                    ParticipantId = userId,
                    SeminarId = seminar.Id,
                };

                await _context.SeminarsParticipants.AddAsync(seminarParticipant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<AddSeminarViewModel> GetAddSeminarModelAsync()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            var model = new AddSeminarViewModel
            {
                Categories = categories
            };

            return model;
        }

        public async Task<IEnumerable<AllSeminarViewModel>> GetAllSeminarsAsync()
        {
            return await _context.Seminars
                .Select(s => new AllSeminarViewModel
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    Organizer = s.Organizer.UserName,
                    Category = s.Category.Name,
                    DateAndTime = s.DateAndTime.ToString("dd/MM/yyyy HH:mm")
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<JoinedSeminarViewModel>> GetJoinedSeminarsAsync(string userId)
        {
            return await _context.SeminarsParticipants
                .Where(sp => sp.ParticipantId == userId)
                .Select(s => new JoinedSeminarViewModel
                {
                    Id = s.SeminarId,
                    Topic = s.Seminar.Topic,
                    Lecturer = s.Seminar.Lecturer,
                    DateAndTime = s.Seminar.DateAndTime.ToString("dd/MM/yyyy HH:mm"),
                    Category = s.Seminar.Category.Name,
                    Organizer = s.Seminar.Organizer.UserName,
                }).ToListAsync();
        }

        public async Task<JoinSeminarViewModel?> GetSeminarByIdAsync(int id)
        {
            return await _context.Seminars
                .Where(s => s.Id == id)
                .Select(s => new JoinSeminarViewModel
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    Details = s.Details,
                    OrganizerId = s.OrganizerId,
                    DateAndTime = s.DateAndTime,
                    Duration = s.Duration,
                    CategoryId = s.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task LeaveSeminar(string userId, JoinSeminarViewModel seminar)
        {
            var userSeminar = await _context.SeminarsParticipants
                    .FirstOrDefaultAsync(sp => sp.SeminarId == seminar.Id && sp.ParticipantId == userId);

            if (userSeminar != null)
            {
                _context.SeminarsParticipants.Remove(userSeminar);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<SeminarDetailsViewModel> GetSeminarDetails(int id)
        {
            var seminarToDisplay = await _context.Seminars
                .Where(s => s.Id == id)
                .Select(s => new SeminarDetailsViewModel
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    OrganizerId = s.OrganizerId,
                    Lecturer = s.Lecturer,
                    Organizer = s.Organizer.UserName,
                    Details = s.Details,
                    Duration = s.Duration,
                    Category = s.Category.Name,
                    DateAndTime = s.DateAndTime.ToString("dd/MM/yyyy HH:mm")
                }).FirstOrDefaultAsync();

            return seminarToDisplay;
        }

        public async Task<AddSeminarViewModel> GetSeminarToEdit(int id)
        {
            var categories = await _context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            var seminarToEdit = await _context.Seminars
                .Where(s => s.Id == id)
                .Select(s => new AddSeminarViewModel
                {
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    Details = s.Details,
                    DateAndTime = s.DateAndTime.ToString("dd/MM/yyyy HH:mm"),
                    Duration = s.Duration,
                    OrganizerId = s.OrganizerId,
                    CategoryId = s.CategoryId,
                    Categories = categories
                })
                .FirstOrDefaultAsync();

            return seminarToEdit;
        }

        public async Task<Seminar> FindAsync(int id)
        {
            return await _context.Seminars.FindAsync(id);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();
        }

        public async Task EditSeminarAsync(AddSeminarViewModel model, Seminar seminarToEdit)
        {
            string dateTimeString = $"{model.DateAndTime}";

            if (!DateTime.TryParseExact(dateTimeString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
            {
                throw new InvalidOperationException("Invalid date or time format");
            }

            seminarToEdit.Topic = model.Topic;
            seminarToEdit.Lecturer = model.Lecturer;
            seminarToEdit.Details = model.Details;
            seminarToEdit.DateAndTime = parsedDateTime;
            seminarToEdit.Duration = model.Duration.Value;
            seminarToEdit.CategoryId = model.CategoryId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeminarAsync(Seminar seminar)
        {
            _context.Seminars.Remove(seminar);
            await _context.SaveChangesAsync();
        }
    }
}
