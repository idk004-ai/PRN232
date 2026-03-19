using Newtonsoft.Json;
using BusinessObjects.Models.DTOs.Attachment;
using BusinessObjects.Models.DTOs.Comment;
using BusinessObjects.Models.DTOs.Feed;
using BusinessObjects.Models.DTOs.Major;
using BusinessObjects.Models.DTOs.Notification;
using BusinessObjects.Models.DTOs.Post;
using BusinessObjects.Models.DTOs.Profile;
using BusinessObjects.Models.DTOs.Report;
using BusinessObjects.Models.DTOs.Topic;
using BusinessObjects.Models.DTOs.User;
using BusinessObjects.Models.Entities;

namespace ProductWebAPI.Mappers;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        #region User
        CreateMap<ApplicationUser, UserDTO>()
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Profile != null ? src.Profile.Avatar : string.Empty))
            .ForMember(dest => dest.Banner, opt => opt.MapFrom(src => src.Profile != null ? src.Profile.Banner : string.Empty))
            .ForMember(dest => dest.LockoutEnd, opt => opt.MapFrom(src => src.LockoutEnd))
            ;
        #endregion

        #region Profile
        CreateMap<Profile, ProfileDTO>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (int)src.Gender))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.Discipline, opt => opt.MapFrom(src => src.Major != null ? src.Major.Name : string.Empty))
        .ReverseMap();
        #endregion

        #region Major
        CreateMap<Major, MajorDTO>().ReverseMap();
        CreateMap<CreateMajorDTO, Major>();
        CreateMap<UpdateMajorDTO, Major>();
        CreateMap<Major, MajorTrashDTO>()
            .ForMember(dest => dest.TotalDateDeleted, opt => opt.MapFrom(src => src.DateDeleted.HasValue ? (src.DateDeleted.Value - DateTime.Now).Days : 0));
        #endregion

        #region Post
        CreateMap<CreatePostDTO, Post>()
           .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now)); CreateMap<Post, PostDTO>()
        .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Creater.UserName))
        .ForMember(dest => dest.AuthorAvatar, opt => opt.MapFrom(src => src.Creater.Profile != null ? src.Creater.Profile.Avatar : string.Empty))
        .ForMember(dest => dest.TopicName, opt => opt.MapFrom(src => src.Topic != null ? src.Topic.Name : string.Empty))
        .ForMember(dest => dest.TopicId, opt => opt.MapFrom(src => src.Topic != null ? src.Topic.Id : (Guid?)null))
        .ForMember(dest => dest.TopicAvatar, opt => opt.MapFrom(src => src.Topic != null ? src.Topic.Avatar : string.Empty))
        .ForMember(dest => dest.UpVoteCount, opt => opt.MapFrom(src => src.Votes.Count(v => v.IsUp)))
        .ForMember(dest => dest.DownVoteCount, opt => opt.MapFrom(src => src.Votes.Count(v => !v.IsUp)))
        .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.Comments.Count))
        .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
        .ForMember(dest => dest.InTrash, opt => opt.MapFrom(src => src.IsDeleted))
        .ForMember(dest => dest.Elapsed, opt => opt.MapFrom(src => DateTime.Now - src.CreatedAt))
        .ForMember(dest => dest.TotalDateDeleted, opt => opt.MapFrom(src => src.DateDeleted.HasValue ? (src.DateDeleted.Value - DateTime.Now).Days : 0))
        .ReverseMap();
        CreateMap<RecentPost, RecentPostDTO>().ReverseMap();
        CreateMap<EditPostDTO, Post>();
        #endregion

        #region Attachment
        CreateMap<Attachment, AttachmentDTO>()
             .ReverseMap()
             .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now));
        #endregion

        #region Topic
        CreateMap<Topic, TopicDTO>().ReverseMap();
        CreateMap<EditTopicDTO, Topic>();
        CreateMap<CreateTopicDTO, Topic>();
        CreateMap<Topic, TopicTrashDTO>()
            .ForMember(dest => dest.TotalDateDeleted, opt => opt.MapFrom(src => src.DateDeleted.HasValue ? (src.DateDeleted.Value - DateTime.Now).Days : 0));
        #endregion

        #region Comment
        CreateMap<Comment, CommentDTO>()
        .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Creater.UserName))
        .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Creater.Profile != null ? src.Creater.Profile.Avatar : string.Empty))
        .ForMember(dest => dest.TopicName, opt => opt.MapFrom(src => src.Post.Topic != null ? src.Post.Topic.Name : string.Empty))
        .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.Post.Id))
        .ForMember(dest => dest.AttachmentId, opt => opt.MapFrom(src => src.Attachment!.Id))
        .ForMember(dest => dest.ReplyId, opt => opt.MapFrom(src => src.ReplyTo!.Id))
        .ForMember(dest => dest.Elapsed, opt => opt.MapFrom(src => DateTime.Now - src.CreatedAt))
        .ReverseMap();
        CreateMap<CommentUpdateDTO, Comment>();
        #endregion

        #region Feed
        CreateMap<Feed, FeedDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
                    src.Creater != null ? src.Creater.UserName : string.Empty))
                .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics));
        CreateMap<CreateFeedDTO, Feed>();
        #endregion
        #region Notification
        CreateMap<Notification, NotificationDTO>()
            .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver.UserName))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ReverseMap()
            .ForPath(dest => dest.Receiver.UserName, opt => opt.MapFrom(src => src.Receiver))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
        #endregion
        #region Report
        CreateMap<Report, ReportDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src =>
                JsonConvert.DeserializeObject<ReportContent>(src.Content) ?? new ReportContent()))
            .ForMember(dest => dest.ResponseContent, opt => opt.MapFrom(src => src.ResponseContent))
            .ForMember(dest => dest.Creater, opt => opt.MapFrom(src => src.Creater.Email))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src =>
                JsonConvert.SerializeObject(src.Content) ?? string.Empty))
            .ForMember(dest => dest.ResponseContent, opt => opt.MapFrom(src => src.ResponseContent))
            .ForMember(dest => dest.Creater, opt => opt.MapFrom<ReportResolver>());
        #endregion
    }
}