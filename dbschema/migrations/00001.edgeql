CREATE MIGRATION m1bjtruhmxeuc2nxlipdxgj2xjm25nljkh5qbewdxj3ngcdvrwitpa
    ONTO initial
{
  CREATE TYPE default::Post {
      CREATE REQUIRED PROPERTY postId: std::str {
          SET readonly := true;
          CREATE CONSTRAINT std::exclusive;
      };
      CREATE REQUIRED PROPERTY score: std::int32;
      CREATE REQUIRED PROPERTY title: std::str;
  };
  CREATE TYPE default::User {
      CREATE REQUIRED PROPERTY name: std::str {
          SET readonly := true;
          CREATE CONSTRAINT std::exclusive;
      };
  };
};
