using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using WebAPI.Models;

namespace WebAPI.Persistance
{
    public class StudentCoursesRepository : IStudentCoursesRepository
    {
        private readonly NHibernate.ISession _session;

        public StudentCoursesRepository(NHibernate.ISession session){
            _session = session;
        }

        public StudentCourses Add(StudentCourses studentCourses)
        {
            using var transaction = _session.BeginTransaction();
            _session.Save(studentCourses);
            transaction.Commit();
            return studentCourses;
        }

        public void Delete(string emplid, string courseId)
        {
            using var transaction = _session.BeginTransaction();
            var studentCourses = _session.Get<StudentCourses>(emplid, courseId);
            if (studentCourses != null)
            {
                _session.Delete(studentCourses);
                transaction.Commit();
            }
        }

        public StudentCourses Get(string emplid, string courseId)
        {
            return _session.Get<StudentCourses>(emplid, courseId);
        }

        public IEnumerable<StudentCourses> GetAll()
        {
            return _session.Query<StudentCourses>().ToList();
        }

        public bool Update(StudentCourses studentCourses)
        {
            using var transaction = _session.BeginTransaction();
            try
            {
                _session.Update(studentCourses);
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}
