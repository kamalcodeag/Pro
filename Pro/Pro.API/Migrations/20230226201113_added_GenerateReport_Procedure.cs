using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pro.API.Migrations
{
    /// <inheritdoc />
    public partial class added_GenerateReport_Procedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR REPLACE PROCEDURE public.""sp_GenerateRport""()

                        LANGUAGE 'sql'
                        AS $BODY$
                        INSERT INTO public.""Reports""
                        (
							SELECT 	u.""Id"",
									u.""UserName"",
									u.""Email"",
									ud.""FirstName"",
									ud.""LastName"",
									ud.""Description"",
									ud.""UserId""
							FROM public.""Users"" u
							JOIN public.""UserDetails"" ud on u.""Id"" = ud.""UserId""
						)
                        $BODY$;
                        ALTER PROCEDURE public.""sp_GenerateRport""()
                            OWNER TO postgres;";

            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
