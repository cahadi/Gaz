using Gaz.Domain.Repositories.Abstract;
using Gaz.Domain.Repositories.Abstract.Auth;
using Gaz.Domain.Repositories.Abstract.SendMessage;

namespace Gaz.Domain
{
	public class DataManager
	{
		public IEditTimesRepository EditTimes { get; set; }
		public IEstimationRepository Estimations { get; set; }
		public IEstimationsMarkRepository EstimationsMarks { get; set; }
		public IExplanationRepository Explanations { get; set; }
		public IIndicatorRepository Indicators { get; set; }
		public ILawRepository Laws { get; set; }
		public IMarkRepositpry Marks { get; set; }
		public IOnetypeRepository Onetypes { get; set; }
		public IPollRepository Polls { get; set; }
		public IRoleRepository Roles { get; set; }
		public IRolesLawRepository RolesLaws { get; set; }
		public IScoreRepository Scores { get; set; }
		public IUserRepository Users { get; set; }
		public IUsersRoleRepository UsersRoles { get; set; }

		public IAuthenticateRepository Authenticate { get; set; }
		public IChangePasswordRepository ChangePassword { get; set; }
		public IRegisterRepository Register { get; set; }

		public ISendExselRepository SendExsel { get; set; }

		public DataManager(IEditTimesRepository editTimesRepository,
			IEstimationRepository estimationRepository,
			IEstimationsMarkRepository estimationsMarkRepository,
			IExplanationRepository explanationRepository,
			IIndicatorRepository indicatorRepository,
			ILawRepository lawRepository,
			IMarkRepositpry markRepositpry,
			IOnetypeRepository onetypeRepository,
			IPollRepository pollRepository,
			IRoleRepository roleRepository,
			IRolesLawRepository rolesLawRepository,
			IScoreRepository scoreRepository,
			IUserRepository userRepository,
			IUsersRoleRepository usersRoleRepository,

			IAuthenticateRepository authenticateRepository,
			IChangePasswordRepository changePasswordRepository,
			IRegisterRepository registerRepository,

			ISendExselRepository sendExselRepository)
		{
			EditTimes = editTimesRepository;
			Estimations = estimationRepository;
			EstimationsMarks = estimationsMarkRepository;
			Explanations = explanationRepository;
			Indicators = indicatorRepository;
			Laws = lawRepository;
			Marks = markRepositpry;
			Onetypes = onetypeRepository;
			Polls = pollRepository;
			Roles = roleRepository;
			RolesLaws = rolesLawRepository;
			Scores = scoreRepository;
			Users = userRepository;
			UsersRoles = usersRoleRepository;

			Authenticate = authenticateRepository;
			ChangePassword = changePasswordRepository;
			Register = registerRepository;

			SendExsel = sendExselRepository;
		}
	}
}
