<template>
  <tr>
    <td style="width:90%;text-align:left;">{{ item.text }}</td>
    <td>
      <a @click="$emit('run', item.id)" href="#">
        <span class="glyphicon glyphicon-play"></span>
      </a>
    </td>
    <td>
      <a @click="$emit('edit', item.id)" href="#">
        <span class="glyphicon glyphicon-pencil"></span>
      </a>
    </td>
    <td>
      <a @click="$emit('remove', item.id)" href="#">
        <span class="glyphicon glyphicon-trash"></span>
      </a>
    </td>
  </tr>
</template>

<script>
  export default {
    props: {
      item: {
        type: Object,
        required: true
      }
    }
  }
</script>