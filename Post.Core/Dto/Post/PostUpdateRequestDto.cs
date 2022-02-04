﻿using Microsoft.AspNetCore.Http;

namespace Post.Core.Dto.Post;

public class PostUpdateRequestDto
{
    public Guid PostId { get; set; }
    public IFormFile NewFile { get; set; }
    public string NewDescription { get; set; }
}