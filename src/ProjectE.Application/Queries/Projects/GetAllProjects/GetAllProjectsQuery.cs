using MediatR;
using ProjectE.Application.DTOs.Projects;
using ProjectE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<Response<List<ProjectItemDTO>>>
    {

    }
}
