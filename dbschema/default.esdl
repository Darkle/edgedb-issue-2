module default {
    type Post {
      required postId: str {
        readonly := true; 
        constraint exclusive;
      };
      required title: str;
      required score: int32;
    };
    type User {
      required name: str {
        readonly := true; 
        constraint exclusive;
      };
    };
}
