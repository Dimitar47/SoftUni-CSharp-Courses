using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FilmSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "films",
                columns: new[] { "id", "deleted_at", "duration", "is_active", "title", "year" },
                values: new object[,]
                {
                    { 1, null, 120, true, "Film 1", 1921 },
                    { 2, null, 120, true, "Film 2", 1922 },
                    { 3, null, 120, true, "Film 3", 1923 },
                    { 4, null, 120, true, "Film 4", 1924 },
                    { 5, null, 120, true, "Film 5", 1925 },
                    { 6, null, 120, true, "Film 6", 1926 },
                    { 7, null, 120, true, "Film 7", 1927 },
                    { 8, null, 120, true, "Film 8", 1928 },
                    { 9, null, 120, true, "Film 9", 1929 },
                    { 10, null, 120, true, "Film 10", 1930 },
                    { 11, null, 120, true, "Film 11", 1931 },
                    { 12, null, 120, true, "Film 12", 1932 },
                    { 13, null, 120, true, "Film 13", 1933 },
                    { 14, null, 120, true, "Film 14", 1934 },
                    { 15, null, 120, true, "Film 15", 1935 },
                    { 16, null, 120, true, "Film 16", 1936 },
                    { 17, null, 120, true, "Film 17", 1937 },
                    { 18, null, 120, true, "Film 18", 1938 },
                    { 19, null, 120, true, "Film 19", 1939 },
                    { 20, null, 120, true, "Film 20", 1940 },
                    { 21, null, 120, true, "Film 21", 1941 },
                    { 22, null, 120, true, "Film 22", 1942 },
                    { 23, null, 120, true, "Film 23", 1943 },
                    { 24, null, 120, true, "Film 24", 1944 },
                    { 25, null, 120, true, "Film 25", 1945 },
                    { 26, null, 120, true, "Film 26", 1946 },
                    { 27, null, 120, true, "Film 27", 1947 },
                    { 28, null, 120, true, "Film 28", 1948 },
                    { 29, null, 120, true, "Film 29", 1949 },
                    { 30, null, 120, true, "Film 30", 1950 },
                    { 31, null, 120, true, "Film 31", 1951 },
                    { 32, null, 120, true, "Film 32", 1952 },
                    { 33, null, 120, true, "Film 33", 1953 },
                    { 34, null, 120, true, "Film 34", 1954 },
                    { 35, null, 120, true, "Film 35", 1955 },
                    { 36, null, 120, true, "Film 36", 1956 },
                    { 37, null, 120, true, "Film 37", 1957 },
                    { 38, null, 120, true, "Film 38", 1958 },
                    { 39, null, 120, true, "Film 39", 1959 },
                    { 40, null, 120, true, "Film 40", 1960 },
                    { 41, null, 120, true, "Film 41", 1961 },
                    { 42, null, 120, true, "Film 42", 1962 },
                    { 43, null, 120, true, "Film 43", 1963 },
                    { 44, null, 120, true, "Film 44", 1964 },
                    { 45, null, 120, true, "Film 45", 1965 },
                    { 46, null, 120, true, "Film 46", 1966 },
                    { 47, null, 120, true, "Film 47", 1967 },
                    { 48, null, 120, true, "Film 48", 1968 },
                    { 49, null, 120, true, "Film 49", 1969 },
                    { 50, null, 120, true, "Film 50", 1970 },
                    { 51, null, 120, true, "Film 51", 1971 },
                    { 52, null, 120, true, "Film 52", 1972 },
                    { 53, null, 120, true, "Film 53", 1973 },
                    { 54, null, 120, true, "Film 54", 1974 },
                    { 55, null, 120, true, "Film 55", 1975 },
                    { 56, null, 120, true, "Film 56", 1976 },
                    { 57, null, 120, true, "Film 57", 1977 },
                    { 58, null, 120, true, "Film 58", 1978 },
                    { 59, null, 120, true, "Film 59", 1979 },
                    { 60, null, 120, true, "Film 60", 1980 },
                    { 61, null, 120, true, "Film 61", 1981 },
                    { 62, null, 120, true, "Film 62", 1982 },
                    { 63, null, 120, true, "Film 63", 1983 },
                    { 64, null, 120, true, "Film 64", 1984 },
                    { 65, null, 120, true, "Film 65", 1985 },
                    { 66, null, 120, true, "Film 66", 1986 },
                    { 67, null, 120, true, "Film 67", 1987 },
                    { 68, null, 120, true, "Film 68", 1988 },
                    { 69, null, 120, true, "Film 69", 1989 },
                    { 70, null, 120, true, "Film 70", 1990 },
                    { 71, null, 120, true, "Film 71", 1991 },
                    { 72, null, 120, true, "Film 72", 1992 },
                    { 73, null, 120, true, "Film 73", 1993 },
                    { 74, null, 120, true, "Film 74", 1994 },
                    { 75, null, 120, true, "Film 75", 1995 },
                    { 76, null, 120, true, "Film 76", 1996 },
                    { 77, null, 120, true, "Film 77", 1997 },
                    { 78, null, 120, true, "Film 78", 1998 },
                    { 79, null, 120, true, "Film 79", 1999 },
                    { 80, null, 120, true, "Film 80", 2000 },
                    { 81, null, 120, true, "Film 81", 2001 },
                    { 82, null, 120, true, "Film 82", 2002 },
                    { 83, null, 120, true, "Film 83", 2003 },
                    { 84, null, 120, true, "Film 84", 2004 },
                    { 85, null, 120, true, "Film 85", 2005 },
                    { 86, null, 120, true, "Film 86", 2006 },
                    { 87, null, 120, true, "Film 87", 2007 },
                    { 88, null, 120, true, "Film 88", 2008 },
                    { 89, null, 120, true, "Film 89", 2009 },
                    { 90, null, 120, true, "Film 90", 2010 },
                    { 91, null, 120, true, "Film 91", 2011 },
                    { 92, null, 120, true, "Film 92", 2012 },
                    { 93, null, 120, true, "Film 93", 2013 },
                    { 94, null, 120, true, "Film 94", 2014 },
                    { 95, null, 120, true, "Film 95", 2015 },
                    { 96, null, 120, true, "Film 96", 2016 },
                    { 97, null, 120, true, "Film 97", 2017 },
                    { 98, null, 120, true, "Film 98", 2018 },
                    { 99, null, 120, true, "Film 99", 2019 },
                    { 100, null, 120, true, "Film 100", 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "films",
                keyColumn: "id",
                keyValue: 100);
        }
    }
}
