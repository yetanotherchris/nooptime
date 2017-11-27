<template>
  <div>
    <table class="table table-striped" v-if="items.length">
      <tbody>
        <StatusItem 
          v-for="item in items" 
          :key="item.id"
          :item="item" 
           />
      </tbody>
    </table>
    <p v-else>
      Nothing here.
    </p>
  </div>
</template>

<script>
  import StatusItem from "./StatusItem.vue";

  export default {
    components: {
      StatusItem
    },
    data() {
      return {
        items: [
          {
            id: 1,
            text: "Check google.com",
            checkType : "HTTP",
            uptime: 99,
            checks: [ 
              1,1,1,1,1,1,
              1,1,1,1,1,1,
              1,1,1,1,1,1,
              1,1,1,1,0,1
            ]
          },
          {
            id: 2,
            text: "Check the database",
            checkType : "SQL",
            uptime: 82,
            checks: [ 
              1,1,1,0,1,1,
              0,1,1,1,1,1,
              1,0,1,0,1,1,
              1,1,1,1,0,1
            ]
          },
          {
            id: 3,
            text: "Ping a Windows 2003 server",
            checkType: "Ping",
            uptime: 95,
            checks: [ 
              1,1,1,1,1,1,
              1,0,1,0,1,1,
              1,1,1,1,1,1,
              1,0,1,1,1,1
            ]
          }
        ]
      };
    }
  };
</script>