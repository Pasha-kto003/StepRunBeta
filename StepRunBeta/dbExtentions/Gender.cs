using ModelsApi;

namespace StepRunBeta.DB 
{ 

    public partial class Gender
    {
        public static explicit operator GenderApi(Gender gender)
        {
            return new GenderApi
            {
                Id = gender.Id,
                GenderName = gender.GenderName
            };
        }

        public static explicit operator Gender(GenderApi gender)
        {
            return new Gender
            {
                Id = gender.Id,
                GenderName = gender.GenderName
            };
        }
    }
}
