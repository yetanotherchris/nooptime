<template>
  <tr>
    <td style="text-align:left;">{{ item.text }}</td>
    <td style="width:3%">
      <a @click="$emit('run', item.id)" href="#">
        <span class="oi oi-play-circle"></span>
      </a>
    </td>
    <td style="width:3%">
      <a @click="$emit('edit', item.id)" href="#">
        <span class="oi oi-pencil"></span>
      </a>
    </td>
    <td style="width:3%">
      <a @click="$emit('remove', item.id)" href="#">
        <span class="oi oi-trash"></span>
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