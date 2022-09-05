using ModelsApi;

namespace StepRunBeta.DB
{
    public partial class Passport
    {
        public static explicit operator PassportApi(Passport passport)
        {
            return new PassportApi
            {
                Id = passport.Id,
                Series = passport.Series,
                Number = passport.Number,
                DateEnd = passport.DateEnd,
                DateStart = passport.DateStart
            };
        }

        public static explicit operator Passport(PassportApi passport)
        {
            return new Passport
            {
                Id = passport.Id,
                Series = passport.Series,
                Number = passport.Number,
                DateEnd = passport.DateEnd,
                DateStart = passport.DateStart
            };
        }
    }
}
