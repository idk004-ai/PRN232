using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Constants;

namespace BusinessObjects.Helpers;
public static class ModelBuilderExtensions
{
    public static void SeedDatabase(this ModelBuilder builder)
    {

        var roles = UserRole.ALL.Select(role => new IdentityRole
        {
            Name = role,
            NormalizedName = role.ToUpper()
        }).ToList();
        var topics = UserTopic.TOPICS_DATA.Select(t => new Models.Entities.Topic
        {
            Id = Guid.NewGuid(),
            Name = t.Name,
            Description = t.Description,
            IsDeleted = false,
            NeedReview = false,
            Panner = "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19",
            Avatar = "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19"
        }).ToList();
        var majors = UserMajor.All.Select(major => new Models.Entities.Major
        {
            Id = Guid.NewGuid(),
            Name = major,
            Description = "A major of FPT University"
        }).ToList();

        builder.Entity<Models.Entities.Topic>().HasData(topics);
        builder.Entity<IdentityRole>().HasData(roles);
        builder.Entity<Models.Entities.Major>().HasData(majors);
        SeedMajorTopicRelations(builder, majors, topics);
    }
    private static void SeedMajorTopicRelations(ModelBuilder builder, List<Models.Entities.Major> majors,
     List<Models.Entities.Topic> topics)
    {
        var majorTopicRelations = new List<object>
    {
        // Major: SOFTWARE_ENGINEERING
        new { MajorsId = majors.First(m => m.Name == UserMajor.SOFTWARE_ENGINEERING).Id, TopicsId = topics.First(t => t.Name == "SWT301").Id },
        new { MajorsId = majors.First(m => m.Name == UserMajor.SOFTWARE_ENGINEERING).Id, TopicsId = topics.First(t => t.Name == "SWE201c").Id },
        new { MajorsId = majors.First(m => m.Name == UserMajor.SOFTWARE_ENGINEERING).Id, TopicsId = topics.First(t => t.Name == "PRJ301").Id },
        new { MajorsId = majors.First(m => m.Name == UserMajor.SOFTWARE_ENGINEERING).Id, TopicsId = topics.First(t => t.Name == "PRO192").Id },

        // Major: JAPANESE_LANGUAGE
        new { MajorsId = majors.First(m => m.Name == UserMajor.JAPANESE_LANGUAGE).Id, TopicsId = topics.First(t => t.Name == "JPD123").Id },
        new { MajorsId = majors.First(m => m.Name == UserMajor.JAPANESE_LANGUAGE).Id, TopicsId = topics.First(t => t.Name == "JPD113").Id },

        // Major: FINANCE
        new { MajorsId = majors.First(m => m.Name == UserMajor.FINANCE).Id, TopicsId = topics.First(t => t.Name == "MAS291").Id },

        // Major: INFORMATION_SYSTEMS
        new { MajorsId = majors.First(m => m.Name == UserMajor.INFORMATION_SYSTEMS).Id, TopicsId = topics.First(t => t.Name == "IOT102").Id }
    };

        // Seed bảng trung gian MajorTopic
        builder.Entity("tblMajorTopics").HasData(majorTopicRelations);
    }

}