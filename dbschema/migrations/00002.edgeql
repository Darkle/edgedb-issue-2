CREATE MIGRATION m1mp4cksws6ycv4knzgljmbidvlrsoivc2h64dywtjpi4hs6alrwiq
    ONTO m1bjtruhmxeuc2nxlipdxgj2xjm25nljkh5qbewdxj3ngcdvrwitpa
{
  ALTER TYPE default::Post {
      ALTER PROPERTY postId {
          DROP CONSTRAINT std::exclusive;
      };
  };
  ALTER TYPE default::User {
      ALTER PROPERTY name {
          DROP CONSTRAINT std::exclusive;
      };
  };
};
